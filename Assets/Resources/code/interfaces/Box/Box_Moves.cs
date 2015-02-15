using UnityEngine;
using System.Collections;

public class Box_Moves : Interface {

	private float sx = 2.4f;
	private bool  platformed = false;
	private object direction;
	
	private ObjectController objCtrl;

	public Box_Moves() : base( "sx" , "right" , "left" ) {
		this.executable = true;
		this.initActive = true;
	}

	protected override void SetStartingValues ()
	{
		base.SetStartingValues ();
		objCtrl = GetComponent<ObjectController> ();
	}

	public override void Execute (){
		float sx = properties.GetPropertyNumber( "sx" );
		float pl = properties.GetPropertyNumber( "onplatform" );

		Vector2 point = new Vector2 (transform.position.x, transform.position.y);
		if( pl != 0 ){
			if( ThereIsBlock( Vector2.right/2 * Mathf.Sign (pl) ) )
				pl = 0;
		}

		if( pl == 0 && platformed && !IsInvoking( "StopMoving" ) ){
			StopMoving();
			platformed = false;
		}

		if( pl != 0 && !platformed && !IsInvoking( "StopMoving" ) ){
			print ("here");
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
		objCtrl.PlaySound ("rock");
		float newx = 0;
		if( properties.GetPropertyNumber( "onplatform" ) != 0 ){
			Collider2D c = Physics2D.OverlapPoint( transform.position - Vector3.up );
			if( c != null ){
				Vector3 pos = c.transform.parent.position;
				newx = pos.x + Mathf.Round( transform.position.x - pos.x );
			}else{
				properties.SetProperty( "onplatform" , 0);
			}
		}else
			newx = Mathf.Round( transform.position.x );

		transform.position = new Vector3( newx , transform.position.y , 0 );
		properties.SetProperty( "sx" , 0 );
		properties.SetProperty( "right" , false );
		properties.SetProperty( "left" 	, false );
		GetComponent<PushAble> ().canBePushed = true;
	}

	private bool ThereIsBlock( Vector3 shift ){
		Vector3 point = transform.position + shift;
		Collider2D c = Physics2D.OverlapPoint( point );
		if( c == null ) return false;

		if( c.GetComponent<Block_TypeDetection>() != null || c.GetComponent<Box_Moves>() != null || c.GetComponent<DoorController>() != null ) return true;
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
		this.direction = direction;
		if(IsInvoking("ActualPush")){
			CancelInvoke("ActualPush");
		}
		Invoke ("ActualPush", 0.1f);
		GetComponent<PushAble> ().canBePushed = false;
	}

	private void ActualPush(){
		GetComponent<Box_Controller> ().Touched ();
		int dir = int.Parse( direction.ToString() );
		if( dir == 1 )
			MoveRight();
		else if( dir == -1 )
			MoveLeft();
	}
}
