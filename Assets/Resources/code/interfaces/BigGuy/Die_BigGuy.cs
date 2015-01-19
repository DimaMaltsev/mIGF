using UnityEngine;
using System.Collections;

public class Die_BigGuy : Interface {

	Rigidbody2D rb;
	private bool dead = false;
	private ObjectController objCtrl;

	public Die_BigGuy() : base ( "die" ) {
		this.executable = true;
		this.initActive = true;
	}

	protected override void SetStartingValues ()
	{
		base.SetStartingValues ();
		objCtrl = GetComponent<ObjectController> ();
	}

	public override void Execute ()
	{
		bool die = properties.GetPropertyBoolean( "die" );

		if( !die ){
			if( rb == null )
				rb = GetComponent<Rigidbody2D>();
		}else{
			if( rb != null )
				Destroy( rb );
			if( !IsInvoking( "DestroyGameObject" ) )
				Invoke ( "DestroyGameObject" , 0.6f );
		}
	}

	private void TheyWantMeToDie( string reason ){
		if( dead ) return;
		dead = true;

		objCtrl.PlaySound ("gwo_poof");

		if( reason == "KillArea" ){
			if( !IsInvoking( "DestroyGameObject" ) ){
				Messenger.Broadcast<float>( "FreezeCamera" , 1 );
				Invoke ( "DestroyGameObject" , 1 );
			}
		}
		else
			properties.SetProperty( "die" , true );
	}

	private void DestroyGameObject(){
		Messenger.Broadcast( "BigGuyDead" );
		GetComponent<Dieable>().DestroyMyself();
	}
}
