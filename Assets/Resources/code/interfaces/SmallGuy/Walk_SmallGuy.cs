using UnityEngine;
using System.Collections;

public class Walk_SmallGuy : Interface {
	private Rigidbody2D 	rb;
	private PolygonCollider2D 	bc;

	private float rbEnableTime = 0.7f;
	private float deathAnimationTime = 0.8f;

	private ObjectController objCtrl;

	private bool dead = false;

	public Walk_SmallGuy() : base ( "sx" , "x" , "die" , "onplatform" ) {
		this.executable = true;
		this.initActive = true;
	}

	protected override void SetStartingValues ()
	{
		//rb = GetComponent<Rigidbody2D>();
		bc = GetComponent<PolygonCollider2D>();

		bc.sharedMaterial = new PhysicsMaterial2D();
		bc.sharedMaterial.friction = 0;
		
		objCtrl = GetComponent<ObjectController> ();
	}

	public override void Execute ()
	{
		bool die = properties.GetPropertyBoolean( "die" );

		if( die ){
			if( !IsInvoking( "DestroyGameObject" ) )
				Invoke ( "DestroyGameObject" , deathAnimationTime );
			if( rb != null )
				RemoveRigidBody();
			return;
		}

		if( rb == null && !IsInvoking( "EnableRigidBody" ) )
			Invoke( "EnableRigidBody" , rbEnableTime );

		if( rb == null ) return;

		float sx = properties.GetPropertyNumber( "sx" );
		float psx= properties.GetPropertyNumber( "onplatform" );
		float sy = rb.velocity.y;
		float dy = 0;

		Vector3 p = transform.position - Vector3.up;
		Collider2D c = Physics2D.OverlapPoint( p );
		bool walled = properties.GetPropertyBoolean( "walled" );


		if( c != null && c.tag == "BigGuy" && c.GetComponent<ObjectController> ().propertyFacade.GetPropertyBoolean ("walled") == false)
			sx = 0;

		bool stopOnWall = Mathf.Sign (psx) == Mathf.Sign (transform.localScale.x);

		if(walled && stopOnWall)
			psx = 0;

		rb.velocity = new Vector2 (0, sy);

		transform.position += new Vector3 (sx + psx, dy, 0) * Time.deltaTime;
		properties.SetProperty( "x" , transform.position.x );
	}

	private void EnableRigidBody(){
		rb = gameObject.AddComponent<Rigidbody2D>();
		rb.fixedAngle = true;
		rb.gravityScale = 6;
	}

	private void RemoveRigidBody(){
		Destroy( rb );
		rb = null;
	}

	private void TheyWantMeToDie( string reason ){
		if( dead == true ) return;
		dead = true;

		objCtrl.PlaySound ("ti_poof");

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
		Messenger.Broadcast( "SmallGuyDead" );
		GetComponent<Dieable>().DestroyMyself();
	}
}
