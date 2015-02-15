using UnityEngine;
using System.Collections;

public class GroundCheck_SmallGuy : Interface {
	private float changeScaleTime = 0.2f;
	public GroundCheck_SmallGuy() : base( "grounded" , "sx" , "onedge" , "walled", "sy" ){
		this.executable = true;
		this.initActive = true;
	}

	private ObjectController objCtrl;

	private bool grounded = false;

	protected override void SetStartingValues ()
	{
		base.SetStartingValues ();
		objCtrl = GetComponent<ObjectController> ();
	}

	public override void Execute ()
	{

		bool wall = CheckWall();
		bool edge = CheckEdge() && !wall;
		bool ground = CheckGround();

		bool nextground = ground || (!edge && !wall);
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();

		if( nextground && !grounded && rb != null && rb.velocity.y < -15 ){
			objCtrl.PlaySound( "ti_fall" );
		}

		grounded = nextground;

		properties.SetProperty( "onedge" , edge && ground );
		properties.SetProperty( "grounded" , nextground);
		properties.SetProperty( "walled" , wall );

		if(!edge && !ground && properties.GetPropertyNumber("sx") == 0 ){
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
		Vector3 p = transform.position - localScale * Vector3.right * 0.4f - Vector3.up;
		Collider2D c = Physics2D.OverlapPoint( p );

		
		if (c != null && c.isTrigger) 
			return false;

		return c != null && CountBigGuyUnderMe(c);
	}

	private bool CheckEdge(){
		float localScale = transform.localScale.x;
		Vector3 p = transform.position + localScale * Vector3.right * 0.4f - Vector3.up;
		Collider2D c = Physics2D.OverlapPoint( p );
		if (c != null && c.isTrigger) 
			return true;
		return c == null || !CountBigGuyUnderMe(c);
	}

	private bool CheckWall(){
		float localScale = transform.localScale.x;
		Vector3 p = transform.position + localScale * Vector3.right * 0.7f;
		Collider2D c = Physics2D.OverlapPoint( p );
		
		return c != null && ( c.GetComponent<Block_TypeDetection>() != null || 
		                     c.GetComponent<Box_Moves>() != null || 
		                     c.GetComponent<CrumblingWallController>() != null || 
		                     c.GetComponent<DoorController>() != null);
	}

	private bool CountBigGuyUnderMe(Collider2D c){
		if(c.GetComponent<Collider_BigGuy>() == null)
			return true;

		if( c.gameObject.layer == 10 )
			return false;
		return true;
	}
}
