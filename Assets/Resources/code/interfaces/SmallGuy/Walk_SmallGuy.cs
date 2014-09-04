using UnityEngine;
using System.Collections;

public class Walk_SmallGuy : Interface {
	private Rigidbody2D 	rb;
	private BoxCollider2D 	bc;

	private float rbEnableTime = 0.9f;
	private float deathAnimationTime = 0.8f;

	public Walk_SmallGuy() : base ( "sx" , "x" , "die" ) {
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
		float sy = rb.velocity.y;

		rb.velocity = new Vector2( sx , sy );

		properties.SetProperty( "x" , transform.position.x );
	}

	private void EnableRigidBody(){
		rb = gameObject.AddComponent<Rigidbody2D>();
		rb.fixedAngle = true;
		rb.gravityScale = 3;
	}

	private void RemoveRigidBody(){
		Destroy( rb );
		rb = null;
	}

	private void DestroyGameObject(){
		Destroy( gameObject );
	}
}
