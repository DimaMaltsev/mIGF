using UnityEngine;
using System.Collections;

public class Box_Moves : Interface {

	public Box_Moves() : base( "sx" , "right" , "left" ) {
		this.executable = true;
		this.initActive = true;
	}

	void OnGUI(){
		if( GUILayout.Button( "Right" ) )
			MoveRight();
		if( GUILayout.Button( "Left" ) )
			MoveLeft();
	}


	public override void Execute (){
		float sx = properties.GetPropertyNumber( "sx" );
		float pl = properties.GetPropertyNumber( "onplatform" );

		transform.position += Vector3.right * ( pl + sx ) * Time.deltaTime;
	}

	private void InvokeStopMoving(){
		if( IsInvoking( "StopMoving" ) )
			CancelInvoke( "StopMoving" );

		Invoke ( "StopMoving" , 0.5f );
	}

	private void MoveRight(){
		properties.SetProperty( "right" , true );
		properties.SetProperty( "left" 	, false );
		properties.SetProperty( "sx" , 1 );
		InvokeStopMoving();
	}

	private void MoveLeft(){
		properties.SetProperty( "right" , false );
		properties.SetProperty( "left" 	, true );
		properties.SetProperty( "sx" , -1 );
		InvokeStopMoving();
	}

	private void StopMoving(){
		properties.SetProperty( "sx" , 0 );
		properties.SetProperty( "right" , false );
		properties.SetProperty( "left" 	, false );
	}
	
}
