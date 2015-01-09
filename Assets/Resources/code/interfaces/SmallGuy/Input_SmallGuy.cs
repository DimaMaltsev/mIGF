using UnityEngine;
using System.Collections;

public class Input_SmallGuy : Interface {

	private float sx = 4.5f;

	public Input_SmallGuy() : base( "sx" , "die" , "jump", "down" ) {
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
		if( Input.GetButton( "Jump" ) )	GetComponent<Dieable>().Die();
		
		properties.SetProperty( "down" , Input.GetButton( "Down" ) );

		bool walled = properties.GetPropertyBoolean( "walled" ) &&
			transform.localScale.x == direction;

		if( walled ) direction = 0;

		properties.SetProperty( "sx" , sx * direction );
	}
}
