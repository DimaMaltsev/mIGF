using UnityEngine;
using System.Collections;

public class Jump_SmallGuy : Interface {

	public float firstJumpPower = 880;
	public float onBigGuyJumpAddition = 100;
	public float secondJumpPower = 780;
	public float jumpReactTime = 0.05f;
	public float canJumpAgainAfter = 0.2f;

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
		//if( jumpsCount == 0 && !properties.GetPropertyBoolean("grounded") ) return;

		bool grounded = properties.GetPropertyBoolean( "grounded" );
		
		if( grounded ){
			jumped = false;
			jumpsCount = 0;
		}

		if( !jump || ( jumped && jumpsCount >= jumpsLimit ) || !jumpButtonReleased)
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

		float jumpAddition = 0;

		if( jumpsCount == 0 && properties.GetPropertyBoolean("grounded")){
			Collider2D c = Physics2D.OverlapPoint( new Vector2(transform.position.x, transform.position.y) - Vector2.up );
			if( c!= null && c.GetComponent<Collider_BigGuy>() != null && !c.GetComponent<Jump_BigGuy>().jumpJustStarted){
				jumpAddition = onBigGuyJumpAddition;
			}
		}

		jumpButtonReleased = false;
		jumpsCount++;
		if( !properties.GetPropertyBoolean("grounded") )
			jumpsCount++;

		properties.SetProperty( "animationJump" , false );
		jumpJustStarted = true;
		jumped = true;
		float vx = rb.velocity.x;
		rb.velocity = new Vector2( vx , 0 );
		rb.AddForce( Vector2.up * ( jumpsCount == 1 ? firstJumpPower + jumpAddition: secondJumpPower ) );
		Invoke( "FinishStartPhase" , canJumpAgainAfter );
	}
}
