using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingPlatformController : Interface {
		
	public List<Vector2> moves = new List<Vector2>();
	public bool looping = false;
	public bool reverseOnEnd = false;
	public float moveSpeed;

	public Vector2 speed;

	private int currentMoveIndex = 0;

	public MovingPlatformController() : base (){
		this.executable = true;
		this.initActive = true;

	}

	protected override void SetStartingValues ()
	{
		moves.Reverse();
		moves.Add( transform.position );
		moves.Reverse();
	}

	public override void Execute ()
	{
		if( moves.Count == 0 ){ 
			Deactivate();
			Debug.LogError( "Moves for Moving_Platform are not defined!" );
			return; 
		}

		MoveToCurrentPoint();
	}

	private void MoveToCurrentPoint(){
		Vector2 pos = transform.position;
		Vector2 currentMove = moves[ currentMoveIndex ];

		if( ( currentMove - pos ).magnitude < moveSpeed * Time.deltaTime){
			transform.position = currentMove;
			NextPoint();
			return;
		}

		speed = ( currentMove - pos ).normalized * moveSpeed;
		Vector2 np = pos + speed * Time.deltaTime;
		transform.position = new Vector3( np.x , np.y , 0 );
	}

	private void NextPoint(){
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
}
