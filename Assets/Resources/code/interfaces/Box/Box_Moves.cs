using UnityEngine;
using System.Collections;

public class Box_Moves : Interface {
	private float sx = 0;
	private float sy = 0;

	private Rigidbody2D rb;
	private Vector3 goal;

	public Box_Moves() : base( "sx" ) {
		this.executable = true;
		this.initActive = true;
	}

	protected override void SetStartingValues ()
	{
		goal = transform.position;
		rb = GetComponent<Rigidbody2D>();
	}

	void OnGUI(){
		if( GUILayout.Button( "Right" ) )
			MoveRight();
		if( GUILayout.Button( "Left" ) )
			MoveLeft();
	}

	public override void Execute (){
		if( sx != 0 )
			MoveBoxHor();
		rb.velocity = new Vector2( sx , rb.velocity.y );
	}

	private void MoveBoxHor(){
		float dist = ( transform.position - goal ).magnitude;
		if( dist <= Mathf.Abs( sx ) * Time.deltaTime ){
			Stop ();
			transform.position = goal;
		}
	}

	private void SetSx( float sx ){
		this.sx = sx;
		properties.SetProperty( "sx" , sx );
	}

	private void SetGoalPoint( int step ){
		goal = new Vector3( Mathf.Floor( transform.position.x + step ) , transform.position.y , 0 );
	}
	private void Stop(){ 
		SetSx( 0 );
	}

	public void MoveRight(){ 
		SetSx( 2.5f );
		SetGoalPoint( 1 );
	}
	public void MoveLeft(){ 
		SetSx( -2.5f );
		SetGoalPoint( -1 );
	}
}
