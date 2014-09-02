using UnityEngine;
using System.Collections;

public class Animation_SmallGuy : Interface {
	private Animator animator;

	private float lastSx = 0;
	private bool  lastEdge = false;

	public Animation_SmallGuy() : base( "sx" , "onedge" ) {
		this.executable = true;
		this.initActive = true;
	}

	protected override void SetStartingValues ()
	{
		animator = GetComponent<Animator>();
	}

	public override void Execute ()
	{
		UpdateDying();
		UpdateRunning();
		UpdateEdge();
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
