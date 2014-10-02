using UnityEngine;
using System.Collections;

public class Jump_SmallGuy : Interface {

	private bool jumped = false;
	private bool jumpButtonReleased = true;
	private Rigidbody2D rb;
	private bool jumpJustStarted = false;

	private int jumpsCount = 0;
	private int jumpsLimit = 2;

	public Jump_SmallGuy() : base( "jump" , "grounded" , "animationJump" ){
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
		
		if( grounded ){
			jumped = false;
			jumpsCount = 0;
		}

		if( !jump || ( jumped && jumpsCount >= jumpsLimit ) || !jumpButtonReleased)
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
		jumpsCount++;
		properties.SetProperty( "animationJump" , false );
		jumpJustStarted = true;
		jumped = true;
		float vx = rb.velocity.x;
		rb.velocity = new Vector2( vx , 0 );
		rb.AddForce( Vector2.up * ( jumpsCount <= 1 ? 810 : 60 ) );
		Invoke( "FinishStartPhase" , 0.2f );
	}
}
