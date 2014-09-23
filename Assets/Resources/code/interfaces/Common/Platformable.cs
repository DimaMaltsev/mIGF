using UnityEngine;
using System.Collections;

public class Platformable : Interface {
	private Rigidbody2D rb;
	public bool MustHaveRigidBody = false;

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
		if( rb == null && MustHaveRigidBody ){
			rb = GetComponent<Rigidbody2D>();
			return;
		}

		float platformSpeed = 0;
		Collider2D c = Physics2D.OverlapPoint( transform.position - Vector3.up );

		if( c != null ){
			Transform pl = GetPlatform( c );
			if( pl != null ){
				float pPlatformSpeed = pl.GetComponent<ObjectController>().propertyFacade.GetPropertyNumber( "onplatform" );
				float pSx = pl.GetComponent<ObjectController>().propertyFacade.GetPropertyNumber( "sx" );

				platformSpeed = pPlatformSpeed + pSx;
			}
		}
		properties.SetProperty( "onplatform" , platformSpeed );
	}

	private Transform GetPlatform( Collider2D c ){

		if( c.transform.parent != null && c.transform.parent.tag == "Moving_Platform" ){
			return c.transform.parent;
		}

		if ( c.GetComponent<Platformable>() != null ){
			return c.transform;
		}
		return null;
	}
}
