﻿using UnityEngine;
using System.Collections;

public class Animation_BigGuy : Interface {
	private Animator a;
	public Animation_BigGuy() : base( "sx" , "animationJump" , "grounded" ){
		this.executable = true;
		this.initActive = true;
	}

	protected override void SetStartingValues ()
	{
		a = GetComponent<Animator>();
	}

	public override void Execute ()
	{
		CheckWalk();
		CheckJump();
		CheckGrounded();
	}

	private void CheckWalk(){
		float sx = properties.GetPropertyNumber( "sx" );
		if( sx == 0 ) {
			a.SetBool( "walk" , false );
			return;
		}
		a.SetBool( "walk" , true );
		float sign = sx / Mathf.Abs( sx );

		if( sign != transform.localScale.x )
			transform.localScale = new Vector3( sx / Mathf.Abs( sx ) , 1 , 1 );
	}

	private void CheckJump(){
		bool jump = properties.GetPropertyBoolean( "animationJump" );
		a.SetBool( "jump" , jump );
	}

	private void CheckGrounded(){
		bool grounded = properties.GetPropertyBoolean( "grounded" );
		a.SetBool( "grounded" , grounded );
	}
}
