using UnityEngine;
using System.Collections;

public class Platformable : Interface {
	private Rigidbody2D rb;
	public Platformable() : base( "onplatform" ){
		this.executable = true;
		this.initActive = true;
	}

	protected override void SetStartingValues ()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	public override void Execute ()
	{
		CheckThePlatform();
	}

	private void CheckThePlatform(){
		if( rb == null ){
			rb = GetComponent<Rigidbody2D>();
			return;
		}

		Collider2D c = Physics2D.OverlapPoint( transform.position - Vector3.up );
		if( c == null ) return;
		float sx = ItsAPlatform( c );
		Vector2 vel = rb.velocity;
		properties.SetProperty( "onplatform" , vel.x + sx );
		vel = new Vector2( vel.x + sx , vel.y );
		rb.velocity = vel;
	}

	private float ItsAPlatform( Collider2D c ){

		if( c.transform.parent != null && c.transform.parent.tag == "Moving_Platform" ){
			return c.transform.parent.GetComponent<ObjectController>().propertyFacade.GetPropertyNumber( "sx" );
		}

		if ( c.GetComponent<Platformable>() != null && c.GetComponent<ObjectController>() != null && c.GetComponent<ObjectController>().propertyFacade.GetPropertyNumber( "onplatform" ) != 0 ){
			return c.GetComponent<ObjectController>().propertyFacade.GetPropertyNumber( "onplatform" );
		}
		return 0;
	}
}
