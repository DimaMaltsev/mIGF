using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingPlatformController : Interface {
		
	public List<Vector3> moves = new List<Vector3>();
	public bool looping = false;
	public bool reverseOnEnd = false;
	public float moveSpeed;
	public float initEdgeWaitingTime = 0;
	public bool moving = true;
	public bool canBeEnabled = false;
	public bool canBeDisabled = false;
	public bool enableDisableOnButtonOut = false;

	public Vector3 speed;

	private int currentMoveIndex = 0;
	private bool edgeWaiting = false;
	private bool activatorTouched = false;
	private bool stoping = false;

	public MovingPlatformController() : base ( "sx" , "onplatform" ){
		this.executable = true;
		this.initActive = true;

	}

	protected override void SetStartingValues ()
	{
		properties.SetProperty( "onplatform" , 0 );
		Vector3 p = transform.position;
		for( int i = 0 ; i < moves.Count ; i++ ){
			moves[ i ] = new Vector3( p.x + moves[ i ].x , p.y + moves[ i ].y  , moves[ i ].z );
		}
		moves.Reverse();
		Vector3 firstPoint = transform.position;
		firstPoint = new Vector3( firstPoint.x , firstPoint.y , initEdgeWaitingTime );
		moves.Add( firstPoint );
		moves.Reverse();
	}

	public override void Execute ()
	{
		if( moves.Count == 0 ){ 
			Deactivate();
			Debug.LogError( "Moves for Moving_Platform are not defined!" );
			return; 
		}

		if( !edgeWaiting && moving )
			MoveToCurrentPoint();
	}

	private void MoveToCurrentPoint(){
		Vector3 pos = transform.position;
		Vector3 currentMove = moves[ currentMoveIndex ];
		currentMove = new Vector3( currentMove.x , currentMove.y , 0 );

		if( ( currentMove - pos ).magnitude < moveSpeed * Time.deltaTime){
			transform.position = currentMove;

			if( !stoping ){
				NextPoint();
			}else{
				moving = false;
				stoping = false;

				properties.SetProperty( "sx" , 0 );
			}
			return;
		}

		speed = ( currentMove - pos ).normalized * moveSpeed;
		speed = new Vector3( speed.x , speed.y , 0 );

		Vector3 np = pos + speed * Time.deltaTime;
		transform.position = new Vector3( np.x , np.y , 0 );

		properties.SetProperty( "sx" , speed.x );
	}

	private void NextPoint(){
		float edgePointTime = moves[ currentMoveIndex ].z;
		edgeWaiting = true;
		
		properties.SetProperty( "sx" , 0 );
		if( edgePointTime != 0 )
			Invoke ( "FinishEdgeWaiting" , edgePointTime );
		else
			FinishEdgeWaiting();

		if( currentMoveIndex == moves.Count - 1 ){
			if( looping ){
				if( reverseOnEnd )
					moves.Reverse();
				currentMoveIndex = 0;
			}
			else
				Deactivate();
			return;
		}

		currentMoveIndex ++;
	}

	private void FinishEdgeWaiting(){
		edgeWaiting = false;
	}

	private void ActivateTrigger(){
		if( !canBeEnabled ) return;
		if( !enableDisableOnButtonOut && activatorTouched ) return;

		moving = true;
		stoping = false;
		activatorTouched = true;
	}

	private void DeActivateTrigger(){
		if( !canBeDisabled ) return;
		if( !enableDisableOnButtonOut && activatorTouched ) return;

		stoping = true;
		activatorTouched = true;
	}
}
