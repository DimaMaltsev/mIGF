using UnityEngine;
using System.Collections;

public class Animation_SmallGuy : Interface {
	private Animator animator;

	private float lastSx = 0;
	private bool  lastEdge = false;
	private bool  lastJump = false;
	private bool  lastGrounded = true;

	public Animation_SmallGuy() : base( "sx" , "onedge" , "animationJump" , "grounded" ) {
		this.executable = true;
		this.initActive = true;
	}

	protected override void SetStartingValues ()
	{
		animator = GetComponent<Animator>();
	}

	public override void Execute ()
	{
		UpdateGround();
		UpdateJump();
		UpdateDying();
		UpdateRunning();
		UpdateEdge();
	}

	private void UpdateGround(){
		bool grounded = properties.GetPropertyBoolean( "grounded" );
		if( grounded != lastGrounded ){
			animator.SetBool( "grounded" , grounded );
			lastGrounded = grounded;
		}
	}

	private void UpdateJump(){
		bool jump = properties.GetPropertyBoolean( "animationJump" );
		if( jump != lastJump ){
			animator.SetBool( "jump" , jump );
			lastJump = jump;
		}
	}

	private void UpdateDying(){
		bool die = properties.GetPropertyBoolean( "die" );
		animator.SetBool( "die" , die );
	}

	private void UpdateEdge(){
		bool onedge = properties.GetPropertyBoolean( "onedge" );

		if( onedge != lastEdge ){
			animator.SetBool( "onedge" , onedge );
			lastEdge = onedge;
		}
	}

	private void UpdateRunning(){
		float sx = properties.GetPropertyNumber( "sx" );
		if( sx != lastSx ){
			animator.SetBool( "running" , sx != 0 );
			
			if( sx > 0 )
				transform.localScale = new Vector3( 1 , 1 , 1 );
			else if( sx < 0 )
				transform.localScale = new Vector3(-1 , 1 , 1 );
			
			lastSx = sx;
		}
	}
}
