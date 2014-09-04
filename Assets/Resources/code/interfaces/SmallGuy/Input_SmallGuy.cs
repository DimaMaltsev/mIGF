using UnityEngine;
using System.Collections;

public class Input_SmallGuy : Interface {

	private float sx = 3;

	public Input_SmallGuy() : base( "sx" , "die" ) {
		this.executable = true;
		this.initActive = true;
	}

	public override void Execute ()
	{
		float direction = 0;
		if( Input.GetButton( "Right" ) ) 	direction++;
		if( Input.GetButton( "Left" ) ) 	direction--;
		if( Input.GetButtonDown( "Up" ) ) 	properties.SetProperty( "jump" , true );
		if( Input.GetButtonUp( "Up" ) ) 	properties.SetProperty( "jump" , false );
		if( Input.GetButton( "Jump" ) )	properties.SetProperty( "die" , true );

		properties.SetProperty( "sx" , sx * direction );
	}
}
