using UnityEngine;
using System.Collections;

public class Jump_BigGuy : Interface {

	private bool jumped = false;
	private bool jumpButtonReleased = true;
	private Rigidbody2D rb;
	private bool jumpJustStarted = false;

	public Jump_BigGuy() : base( "jump" , "grounded" , "animationJump" ){
		this.executable = true;
		this.initActive = true;
	}

	public override void Execute ()
	{
		if( rb == null ){
			rb = GetComponent<Rigidbody2D>();
			return;
		}

		
		bool jump = properties.GetPropertyBoolean( "jump" );

		if( !jump && !jumpButtonReleased )
			jumpButtonReleased = true;

		if( jumpJustStarted ) return;

		bool grounded = properties.GetPropertyBoolean( "grounded" );

		if( grounded )
			jumped = false;



		if( !jump || jumped || !jumpButtonReleased)
			return;

		if( !IsInvoking( "Jump" ) ){
			properties.SetProperty( "animationJump" , true );
			Invoke ( "Jump" , 0.05f );
		}
	}

	private void FinishStartPhase(){
		jumpJustStarted = false;
	}

	private void Jump(){
		if( rb == null ) return;

		jumpButtonReleased = false;
		properties.SetProperty( "animationJump" , false );
		jumpJustStarted = true;
		jumped = true;
		float vx = rb.velocity.x;
		rb.velocity = new Vector2( vx , 0 );
		rb.AddForce( Vector2.up * 950 );
		Invoke( "FinishStartPhase" , 0.8f );
	}
}
