using UnityEngine;
using System.Collections;

public class Platformable : Interface {
	private Rigidbody2D rb;
	public bool MustHaveRigidBody = false;
	public Transform onMe;

	private Transform myLastPlatform;

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
		Collider2D c1 = Physics2D.OverlapPoint( transform.position - Vector3.up );
		Collider2D c2 = Physics2D.OverlapPoint( transform.position - Vector3.up + Vector3.right);
		Collider2D c3 = Physics2D.OverlapPoint( transform.position - Vector3.up - Vector3.right);

		Collider2D[] cls = new Collider2D[]{c1,c2,c3};

		bool foundPlatform = false;

		for (int i = 0; i < cls.Length; i++) {
			Collider2D c = cls[i];
			if( c != null ){
				Transform pl = GetPlatform( c );
				if( pl != null ){
					float pPlatformSpeed = pl.GetComponent<ObjectController>().propertyFacade.GetPropertyNumber( "onplatform" );
					float pSx = pl.GetComponent<ObjectController>().propertyFacade.GetPropertyNumber( "sx" );
					if( pl.GetComponent<Platformable>()!=null ){
						pl.GetComponent<Platformable>().onMe = transform;
						myLastPlatform = pl;
						foundPlatform = true;
					}
					platformSpeed = pPlatformSpeed + pSx;
				}
			}
		}

		if(!foundPlatform && myLastPlatform != null){
			myLastPlatform.GetComponent<Platformable>().onMe = null;
			myLastPlatform = null;
		}

		properties.SetProperty( "onplatform" , platformSpeed );
	}

	private Transform GetPlatform( Collider2D c ){

		if( c.transform.parent != null && c.transform.parent.tag == "Moving_Platform" && !SpesificRejector(c)){
			return c.transform.parent;
		}

		if ( c.GetComponent<Platformable>() != null && !SpesificRejector(c)){
			return c.transform;
		}
		return null;
	}

	private bool SpesificRejector(Collider2D c){
		if( c.GetComponent<Walk_SmallGuy>() != null ) return true;
		if( transform.GetComponent<Box_Moves>() != null && c.GetComponent<Collider_BigGuy>() != null ) return true;
		return false;
	}
}
