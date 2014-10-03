using UnityEngine;
using System.Collections;

public class GroundChecker_BigGuy : Interface {

	public GroundChecker_BigGuy() : base( "grounded" , "sx" , "onedge" , "walled" , "canpush" ){
		this.executable = true;
		this.initActive = true;
	}
	
	public override void Execute ()
	{
		
		bool wall = CheckWall();
		bool edge = CheckEdge() && !wall;
		bool ground = CheckGround() || !edge;
		bool canpush  = CheckPush();

		properties.SetProperty( "onedge" , edge );
		properties.SetProperty( "grounded" , ground );
		properties.SetProperty( "walled" , wall );
		properties.SetProperty( "canpush" , canpush );
	}
	
	private bool CheckGround(){
		float localScale = transform.localScale.x;
		Vector3 p = transform.position - localScale * Vector3.right * 0.3f - Vector3.up * 1.5f;
		Collider2D c = Physics2D.OverlapPoint( p );
		bool grounded = false;
		
		return c != null;
	}
	
	private bool CheckEdge(){
		float localScale = transform.localScale.x;
		Vector3 p = transform.position + localScale * Vector3.right * 0.4f - Vector3.up;
		Collider2D c = Physics2D.OverlapPoint( p );
		
		return c == null;
	}

	private bool CheckWall(){
		float localScale = transform.localScale.x;
		Vector3 p1 = transform.position + localScale * Vector3.right * 0.7f;
		Vector3 p2 = transform.position + localScale * Vector3.right * 0.7f + Vector3.up;
		Collider2D c1 = Physics2D.OverlapPoint( p1 );
		Collider2D c2 = Physics2D.OverlapPoint( p2 );
		return ( c1 != null && c1.GetComponent<Block_TypeDetection>() != null ) || 
			( c2 != null && c2.GetComponent<Block_TypeDetection>() != null );
	}

	private bool CheckPush(){
		float localScale = transform.localScale.x;
		Vector3 p1 = transform.position + localScale * Vector3.right * 0.7f;
		Vector3 p2 = transform.position + localScale * Vector3.right * 0.7f + Vector3.up;
		Collider2D c1 = Physics2D.OverlapPoint( p1 );
		Collider2D c2 = Physics2D.OverlapPoint( p2 );
		return ( c1 != null && c1.GetComponent<PushAble>() != null ) || 
			( c2 != null && c2.GetComponent<PushAble>() != null );
	}
}
