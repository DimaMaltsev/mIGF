using UnityEngine;
using System.Collections;

public class Box_Animation : Interface {
	private Animator a;
	private float lastSX = 0;

	public Box_Animation() : base ( "right" , "left" ){
		this.executable = true;
		this.initActive = true;
	}

	protected override void SetStartingValues ()
	{
		a = GetComponent<Animator>();
	}

	public override void Execute ()
	{
		bool right 	= properties.GetPropertyBoolean( "right" );
		bool left 	= properties.GetPropertyBoolean( "left" );

		if( right ){
			a.SetBool( "rollRight" , true );
			a.SetBool( "rollLeft" , false );
		}else if( left ){
			a.SetBool( "rollRight" , false );
			a.SetBool( "rollLeft" , true );
		}else{
			a.SetBool( "rollRight" , false );
			a.SetBool( "rollLeft" , false );
		}
	}

}
