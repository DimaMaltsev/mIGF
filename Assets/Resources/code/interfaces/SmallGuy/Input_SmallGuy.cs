using UnityEngine;
using System.Collections;

public class Input_SmallGuy : Interface {

	private float sx = 4.5f;
	private bool itIsMenu = false;
	private bool cutScene = false;

	public Input_SmallGuy() : base( "sx" , "die" , "jump", "down" ) {
		this.executable = true;
		this.initActive = true;
	}

	protected override void SetStartingValues ()
	{
		base.SetStartingValues ();
		
		Messenger.AddListener ("CutSceneEnd", CutSceneEnd);
		Messenger.AddListener ("CutSceneStart", CutSceneStart);
	}

	private void CutSceneEnd(){
		cutScene = false;
	}
	
	private void CutSceneStart(){
		cutScene = true;
		properties.SetProperty( "jump" , false );
		properties.SetProperty( "sx" , 0 );
		properties.SetProperty( "down" , false );
	}

	public override void Execute ()
	{
		if( cutScene ) return;

		if( itIsMenu ){
			properties.SetProperty( "sx" , sx );
			return;
		}

		float direction = 0;
		if( Input.GetButton( "Right" ) ) 	direction++;
		if( Input.GetButton( "Left" ) ) 	direction--;
		if( Input.GetButtonDown( "Up" ) || Input.GetButtonDown( "Jump" ) ) 	properties.SetProperty( "jump" , true );
		if( Input.GetButtonUp( "Up" ) || Input.GetButtonUp( "Jump" )) 	properties.SetProperty( "jump" , false );
		
		properties.SetProperty( "down" , Input.GetButton( "Down" ) );

		bool walled = properties.GetPropertyBoolean( "walled" ) &&
			transform.localScale.x == direction;

		if( walled ) direction = 0;

		properties.SetProperty( "sx" , sx * direction );
	}

	public void ItIsMenu(){
		itIsMenu = true;
	}
}
