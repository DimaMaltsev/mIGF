using UnityEngine;
using System.Collections;

public class Jump_SmallGuy : Interface {

	private bool lastJump = false;
	private Rigidbody2D rb;
	private bool jumped = false;

	private int jumpCountLimit = 2;
	private int jumpCount = 0;

	public Jump_SmallGuy() : base( "jump" , "animationJump" , "grounded" ) {
		this.executable = true;
		this.initActive = true;
	}

	public override void Execute ()
	{
		if( jumped )
			properties.SetProperty( "animationJump" , false );

		bool grounded = properties.GetPropertyBoolean( "grounded" );
		bool jump = properties.GetPropertyBoolean( "jump" );

		if( grounded && rb != null && rb.velocity.y < 0 ) 
			jumpCount = 0;

		if( lastJump != jump ){
			if( rb == null ){
				rb = GetComponent<Rigidbody2D> ();
				return;
			}

			if( jump && jumpCount < jumpCountLimit ){
				jumped = true;
				properties.SetProperty( "animationJump" , true );
				if( IsInvoking( "Jump" ) )
					CancelInvoke( "Jump" );

				Invoke ( "Jump" , 0.2f );
			}

			lastJump = jump;
		}
	}

	private void Jump(){
		jumpCount ++;
		float vx = rb.velocity.x;
		rb.velocity = new Vector2( vx , 0 );
		rb.AddForce( Vector2.up * 700 );
	}
}
