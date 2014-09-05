using UnityEngine;
using System.Collections;

public class GroundChecker_BigGuy : Interface {

	public GroundChecker_BigGuy() : base( "grounded" , "sx" , "onedge" ){
		this.executable = true;
		this.initActive = true;
	}
	
	public override void Execute ()
	{
		float localScale = transform.localScale.x;
		Vector3 p = transform.position - localScale * Vector3.right * 0.5f - Vector3.up;
		Collider2D c = Physics2D.OverlapPoint( p );
		bool grounded = false;
		
		if( c != null )
			grounded = true;
		
		p = transform.position + localScale * Vector3.right * 0.5f - Vector3.up;
		c = Physics2D.OverlapPoint( p );
		
		if( c == null )
			properties.SetProperty( "onedge" , true );
		else{
			properties.SetProperty( "onedge" , false );
			grounded = true;
		}
		
		properties.SetProperty( "grounded" , grounded );
	}
}
