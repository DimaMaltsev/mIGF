using UnityEngine;
using System.Collections;

public class Box_Moves : Interface {

	private float sx = 2.4f;
	private bool  platformed = false;

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

		if( pl == 0 && platformed && !IsInvoking( "StopMoving" ) ){
			StopMoving();
			platformed = false;
		}

		if( pl != 0 && !platformed && !IsInvoking( "StopMoving" ) ){
			StopMoving();
		}

		if( pl != 0 )
			platformed = true;




		transform.position += Vector3.right * ( pl + sx ) * Time.deltaTime;
	}

	private void InvokeStopMoving(){
		if( IsInvoking( "StopMoving" ) )
			CancelInvoke( "StopMoving" );

		Invoke ( "StopMoving" , 0.45f );
	}

	public void MoveRight(){
		if( IsInvoking( "StopMoving" ) ) return;

		properties.SetProperty( "right" , true );
		properties.SetProperty( "left" 	, false );
		properties.SetProperty( "sx" , sx );
		InvokeStopMoving();
	}

	public void MoveLeft(){
		if( IsInvoking( "StopMoving" ) ) return;

		properties.SetProperty( "right" , false );
		properties.SetProperty( "left" 	, true );
		properties.SetProperty( "sx" , -sx );
		InvokeStopMoving();
	}

	private void StopMoving(){
		float newx = 0;
		if( properties.GetPropertyNumber( "onplatform" ) != 0 ){
			Vector3 pos = Physics2D.OverlapPoint( transform.position - Vector3.up ).transform.parent.position;
			newx = pos.x + Mathf.Round( transform.position.x - pos.x );
		}else
			newx = Mathf.Round( transform.position.x );

		transform.position = new Vector3( newx , transform.position.y , 0 );
		properties.SetProperty( "sx" , 0 );
		properties.SetProperty( "right" , false );
		properties.SetProperty( "left" 	, false );
	}
	
}
