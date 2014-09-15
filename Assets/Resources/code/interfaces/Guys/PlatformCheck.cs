using UnityEngine;
using System.Collections;

public class PlatformCheck : Interface {

	private Rigidbody2D rb;

	public PlatformCheck() : base( "grounded" , "jump" ){
		this.executable = true;
		this.initActive = true;
	}

	public override void Execute ()
	{
		bool grounded = properties.GetPropertyBoolean( "grounded" );
		if( !grounded ) return;
		if( rb == null ){
			rb = GetComponent<Rigidbody2D>();
			return;
		}

		CheckThePlatform();
	}

	private void CheckThePlatform(){
		Collider2D c = Physics2D.OverlapPoint( transform.position - Vector3.up );
		if( c == null ) return;
		if( c.transform.parent == null || c.transform.parent.tag != "Moving_Platform" ) return;

		Vector2 vel = rb.velocity;
		Vector2 speed = c.transform.parent.GetComponent<MovingPlatformController>().speed;
		vel = new Vector2( vel.x + speed.x , vel.y );
		rb.velocity = vel;
	}
}
