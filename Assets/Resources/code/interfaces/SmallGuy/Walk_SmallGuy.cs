using UnityEngine;
using System.Collections;

public class Walk_SmallGuy : Interface {
	private Rigidbody2D 	rb;
	private BoxCollider2D 	bc;

	private float rbEnableTime = 0.7f;
	private float deathAnimationTime = 0.8f;

	public Walk_SmallGuy() : base ( "sx" , "x" , "die" , "onplatform" ) {
		this.executable = true;
		this.initActive = true;
	}

	protected override void SetStartingValues ()
	{
		//rb = GetComponent<Rigidbody2D>();
		bc = GetComponent<BoxCollider2D>();

		bc.sharedMaterial = new PhysicsMaterial2D();
		bc.sharedMaterial.friction = 0;

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

		Vector3 p = transform.position - Vector3.up;
		Collider2D c = Physics2D.OverlapPoint( p );
		if( c != null && c.tag == "BigGuy" && c.GetComponent<ObjectController>().propertyFacade.GetPropertyBoolean( "walled" ) == false )
			sx = 0;

		rb.velocity = new Vector2( sx + psx , sy );

		properties.SetProperty( "x" , transform.position.x );
	}

	private void EnableRigidBody(){
		rb = gameObject.AddComponent<Rigidbody2D>();
		rb.fixedAngle = true;
		rb.gravityScale = 5;
	}

	private void RemoveRigidBody(){
		Destroy( rb );
		rb = null;
	}

	private void TheyWantMeToDie(){
		properties.SetProperty( "die" , true );
	}
	
	private void DestroyGameObject(){
		Messenger.Broadcast( "SmallGuyDead" );
		GetComponent<Dieable>().DestroyMyself();
	}
}
