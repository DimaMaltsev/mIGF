using UnityEngine;
using System.Collections;

public class GroundCheck_SmallGuy : Interface {
	public GroundCheck_SmallGuy() : base( "grounded" , "sx" , "onedge" , "walled" ){
		this.executable = true;
		this.initActive = true;
	}

	public override void Execute ()
	{

		bool wall = CheckWall();
		bool edge = CheckEdge() && !wall;
		bool ground = CheckGround() || !edge;
		
		properties.SetProperty( "onedge" , edge );
		properties.SetProperty( "grounded" , ground );
		properties.SetProperty( "walled" , wall );
	}

	private bool CheckGround(){
		float localScale = transform.localScale.x;
		Vector3 p = transform.position - localScale * Vector3.right * 0.5f - Vector3.up;
		Collider2D c = Physics2D.OverlapPoint( p );
		bool grounded = false;

		return c != null;
	}

	private bool CheckEdge(){
		float localScale = transform.localScale.x;
		Vector3 p = transform.position + localScale * Vector3.right * 0.5f - Vector3.up;
		Collider2D c = Physics2D.OverlapPoint( p );
		
		return c == null;
	}

	private bool CheckWall(){
		float localScale = transform.localScale.x;
		Vector3 p = transform.position + localScale * Vector3.right * 0.5f;
		Collider2D c = Physics2D.OverlapPoint( p );
		
		return c != null && ( c.GetComponent<Block_TypeDetection>() != null || c.GetComponent<Box_Moves>() != null);
	}
}
