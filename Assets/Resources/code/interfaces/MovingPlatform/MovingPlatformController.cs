using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingPlatformController : Interface {
		
	public List<Vector3> moves = new List<Vector3>();
	public bool looping = false;
	public bool reverseOnEnd = false;
	public float moveSpeed;
	public float initEdgeWaitingTime = 0;

	public Vector3 speed;

	private int currentMoveIndex = 0;
	private bool edgeWaiting = false;

	public MovingPlatformController() : base (){
		this.executable = true;
		this.initActive = true;

	}

	protected override void SetStartingValues ()
	{
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

		if( !edgeWaiting )
			MoveToCurrentPoint();
	}

	private void MoveToCurrentPoint(){
		Vector3 pos = transform.position;
		Vector3 currentMove = moves[ currentMoveIndex ];
		currentMove = new Vector3( currentMove.x , currentMove.y , 0 );

		if( ( currentMove - pos ).magnitude < moveSpeed * Time.deltaTime){
			transform.position = currentMove;
			NextPoint();
			return;
		}

		speed = ( currentMove - pos ).normalized * moveSpeed;
		speed = new Vector3( speed.x , speed.y , 0 );

		Vector3 np = pos + speed * Time.deltaTime;
		transform.position = new Vector3( np.x , np.y , 0 );
	}

	private void NextPoint(){
		float edgePointTime = moves[ currentMoveIndex ].z;
		edgeWaiting = true;

		Invoke ( "FinishEdgeWaiting" , edgePointTime );

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
}
