using UnityEngine;
using System.Collections;

public class Box_Animation : Interface {
	private Animator a;
	private float lastSX = 0;

	public Box_Animation() : base ( "sx" ){
		this.executable = true;
		this.initActive = true;
	}

	protected override void SetStartingValues ()
	{
		a = GetComponent<Animator>();
	}

	public override void Execute ()
	{
		float sx = properties.GetPropertyNumber( "sx" );
		if( lastSX != sx ){
			if( sx > 0 ){
				a.SetBool( "rollRight" , true );
				a.SetBool( "rollLeft" , false );
			}else if( sx < 0 ){
				a.SetBool( "rollRight" , false );
				a.SetBool( "rollLeft" , true );
			}else{
				a.SetBool( "rollRight" , false );
				a.SetBool( "rollLeft" , false );
			}

			lastSX = sx;
		}
	}

}
