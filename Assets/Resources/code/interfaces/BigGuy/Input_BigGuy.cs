using UnityEngine;
using System.Collections;

public class Input_BigGuy : Interface {
	float sx = 4;
	public Input_BigGuy() : base( "sx" , "die" , "jump" , "walled" ){
		this.executable = true;
		this.initActive = true;
	}

	public override void Execute ()
	{
		int direction = 0;
		if( Input.GetButton( "Right" ) ) direction ++;
		if( Input.GetButton( "Left" ) ) direction --;
		
		if( Input.GetButtonDown( "Up" ) ) 	properties.SetProperty( "jump" , true );
		if( Input.GetButtonUp( "Up" ) ) 	properties.SetProperty( "jump" , false );

		properties.SetProperty( "down" , Input.GetButton( "Down" ) );

		if( Input.GetButton( "Jump" ) )		properties.SetProperty( "die" , true );

		bool walled = properties.GetPropertyBoolean( "walled" ) &&
			transform.localScale.x == direction;

		if( walled ) direction = 0;

		properties.SetProperty( "sx" , direction * sx );
	}
}
