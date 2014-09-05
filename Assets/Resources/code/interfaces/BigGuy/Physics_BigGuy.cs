using UnityEngine;
using System.Collections;

public class Physics_BigGuy : Interface {

	private Rigidbody2D rb;

	public Physics_BigGuy() : base( "sx" ){
		this.executable = true;
		this.initActive = true;
	}

	public override void Execute ()
	{
		if( rb == null ){
			AddRigidBody();
			return;
		}

		float sx = properties.GetPropertyNumber( "sx" );
		float sy = rb.velocity.y;

		rb.velocity = new Vector2 ( sx , sy );
	}

	public void AddRigidBody(){
		rb = gameObject.AddComponent<Rigidbody2D>();
		rb.gravityScale = 4;
		rb.fixedAngle = true;
	}
}
