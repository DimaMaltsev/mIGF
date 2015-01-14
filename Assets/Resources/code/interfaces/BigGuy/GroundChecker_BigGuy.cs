using UnityEngine;
using System.Collections;

public class GroundChecker_BigGuy : Interface {
	private float changeScaleTime = 0.2f;

	public GroundChecker_BigGuy() : base( "grounded" , "sx" , "onedge" , "walled" , "canpush" ){
		this.executable = true;
		this.initActive = true;
	}
	
	public override void Execute ()
	{

		bool ground = CheckGround();
		bool wall = CheckWall();
		bool edge = CheckEdge() && (!wall || !ground);
		bool canpush  = CheckPush();

		properties.SetProperty( "onedge" , edge );
		properties.SetProperty( "grounded" , ground || !edge);
		properties.SetProperty( "walled" , wall );
		properties.SetProperty( "canpush" , canpush );

		if(!edge && !ground && properties.GetPropertyNumber("sx") == 0 && ! wall ){
			if( !IsInvoking("ChangeScale") )
				Invoke("ChangeScale",changeScaleTime);
		}else if(IsInvoking("ChangeScale"))
			CancelInvoke("ChangeScale");
	}

	private void ChangeScale(){
		transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y , 1 );
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
		Vector3 p1 = transform.position + localScale * Vector3.right * 1.2f;
		Vector3 p2 = transform.position + localScale * Vector3.right * 1.2f + Vector3.up;
		Collider2D c1 = Physics2D.OverlapPoint( p1 );
		Collider2D c2 = Physics2D.OverlapPoint( p2 );
		return ( c1 != null && ( c1.GetComponent<Block_TypeDetection>() != null || c1.GetComponent<Box_Moves>() != null) ) || 
			( c2 != null && ( c2.GetComponent<Block_TypeDetection>() != null || c2.GetComponent<Box_Moves>() != null));
	}

	private bool CheckPush(){
		float localScale = transform.localScale.x;
		Vector3 p1 = transform.position + localScale * Vector3.right * 1.2f;
		Vector3 p2 = transform.position + localScale * Vector3.right * 1.2f + Vector3.up;
		Collider2D c1 = Physics2D.OverlapPoint( p1 );
		Collider2D c2 = Physics2D.OverlapPoint( p2 );
		return ( c1 != null && c1.GetComponent<PushAble>() != null ) || 
			( c2 != null && c2.GetComponent<PushAble>() != null );
	}
}
