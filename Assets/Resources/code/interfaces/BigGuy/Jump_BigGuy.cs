using UnityEngine;
using System.Collections;

public class Jump_BigGuy : Interface {

	public float jumpPower = 1050;
	public float jumpReactTime = 0.05f;
	public float canJumpAgainAfter = 0.8f;

	private bool jumped = false;
	private bool jumpButtonReleased = true;
	private Rigidbody2D rb;
	public bool jumpJustStarted = false;

	private ObjectController objCtrl;

	public Jump_BigGuy() : base( "jump" , "grounded" , "animationJump" ){
		this.executable = true;
		this.initActive = true;
	}

	protected override void SetStartingValues ()
	{
		base.SetStartingValues ();
		objCtrl = GetComponent<ObjectController> ();
		//objCtrl.PlaySound ("gwo_appears");
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
		if( !properties.GetPropertyBoolean("grounded") ) return;

		bool grounded = properties.GetPropertyBoolean( "grounded" );

		if( grounded )
			jumped = false;

		if( !jump || jumped || !jumpButtonReleased)
			return;

		if( !IsInvoking( "Jump" ) ){
			properties.SetProperty( "animationJump" , true );
			Invoke ( "Jump" , jumpReactTime );
		}
	}

	private void FinishStartPhase(){
		jumpJustStarted = false;
	}

	private void Jump(){
		if( rb == null ) return;

		objCtrl.PlaySound ("gwo_jump");

		jumpButtonReleased = false;
		properties.SetProperty( "animationJump" , false );
		jumpJustStarted = true;
		jumped = true;
		float vx = rb.velocity.x;
		rb.velocity = new Vector2( vx , 0 );
		rb.AddForce( Vector2.up * jumpPower );
		Invoke( "FinishStartPhase" , canJumpAgainAfter );
	}
}
