using UnityEngine;
using System.Collections;

public class Box_Moves : Interface {

	private float sx = 2.4f;
	private bool  platformed = false;

	public Box_Moves() : base( "sx" , "right" , "left" ) {
		this.executable = true;
		this.initActive = true;
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

	private bool MoveRight(){
		if( IsInvoking( "StopMoving" ) || ThereIsBlock( Vector3.right ) ) return false;

		properties.SetProperty( "right" , true );
		properties.SetProperty( "left" 	, false );
		properties.SetProperty( "sx" , sx );
		InvokeStopMoving();
		return true;
	}

	private bool MoveLeft(){
		if( IsInvoking( "StopMoving" ) || ThereIsBlock( Vector3.left ) ) return false;

		properties.SetProperty( "right" , false );
		properties.SetProperty( "left" 	, true );
		properties.SetProperty( "sx" , -sx );
		InvokeStopMoving();
		return true;
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

	private bool ThereIsBlock( Vector3 shift ){
		Vector3 point = transform.position + shift;
		Collider2D c = Physics2D.OverlapPoint( point );
		if( c == null ) return false;

		if( c.GetComponent<Block_TypeDetection>() != null || c.GetComponent<Box_Moves>() != null ) return true;
		return false;
	}

	private void KillMe(){
		Messenger.Broadcast( "BoxDead" );
		GetComponent<Dieable>().DestroyMyself();
	}

	private void TheyWantMeToDie( string reason ){
		if( reason == "KillArea" ){
			if( !IsInvoking( "KillMe" ) ){
				Invoke ( "KillMe" , 1 );
			}
		}else
			KillMe();
	}

	private void IveBeingPushed( object direction ){
		int dir = int.Parse( direction.ToString() );
		if( dir == 1 )
			MoveRight();
		else if( dir == -1 )
			MoveLeft();
	}
}
