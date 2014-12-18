using UnityEngine;
using System.Collections;

public class Box_Moves_Vertical : Interface {

	private float fallingAcceleration = 0.01f;

	public Box_Moves_Vertical() : base ( "sx" , "sy" ){
		this.executable = true;
		this.initActive = true;
	}

	public override void Execute ()
	{
		if( CheckFloor() ){
			properties.SetProperty( "sy" , 0 );
			return;
		}

		FallDown();
	}

	private void FallDown(){
		float x = transform.position.x;
		float y = transform.position.y;
		float sy= properties.GetPropertyNumber( "sy" );

		sy-= fallingAcceleration;
		y += sy;

		properties.SetProperty( "sy" , sy );
		transform.position = new Vector3( x , y , 0 );
	}

	private bool CheckFloor(){
		Collider2D c = Physics2D.OverlapPoint( transform.position - Vector3.up );

		if( c == null ) return false;
		if( 
		   c.GetComponent<Block_TypeDetection>() == null && 
		   c.GetComponent<Box_Moves>() == null && 
		   c.GetComponent<DoorController>() == null && 
		   c.GetComponent<CrumblingWallController>() == null
		   ) 
			return false;

		if( properties.GetPropertyNumber( "sx" ) == 0 ){
			if( c.GetComponent<DoorController>() == null ){
				transform.position = c.transform.position + Vector3.up;
			}else
				transform.position = new Vector3( Mathf.Round( transform.position.x ) , Mathf.Round( transform.position.y ) , 0 );
		}else{
			float x = transform.position.x;
			transform.position = new Vector3( x , c.transform.position.y , 0 ) + Vector3.up;
		}

		return true;
	}
}






