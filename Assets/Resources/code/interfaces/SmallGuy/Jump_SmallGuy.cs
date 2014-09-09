using UnityEngine;
using System.Collections;

public class Jump_SmallGuy : Interface {

	private bool jumped = false;
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
		
		if( jumpJustStarted ) return;
		
		bool jump = properties.GetPropertyBoolean( "jump" );
		bool grounded = properties.GetPropertyBoolean( "grounded" );
		
		if( grounded ){
			jumped = false;
			jumpsCount = 0;
		}

		if( !jump || ( jumped && jumpsCount >= jumpsLimit ) )
			return;
		
		if( !IsInvoking( "Jump" ) ){
			properties.SetProperty( "animationJump" , true );
			Invoke ( "Jump" , 0.2f );
		}
	}
	
	private void FinishStartPhase(){
		jumpJustStarted = false;
	}
	
	private void Jump(){
		jumpsCount++;
		properties.SetProperty( "animationJump" , false );
		jumpJustStarted = true;
		jumped = true;
		float vx = rb.velocity.x;
		rb.velocity = new Vector2( vx , 0 );
		rb.AddForce( Vector2.up * 610 );
		Invoke( "FinishStartPhase" , 0.2f );
	}
}
