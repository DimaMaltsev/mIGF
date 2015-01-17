using UnityEngine;
using System.Collections;

public class Physics_BigGuy : Interface {

	private Rigidbody2D rb;
	private Transform smallGuy;
	private bool layersSleep = false;

	public Physics_BigGuy() : base( "sx" , "die" , "down" , "onplatform" ){
		this.executable = true;
		this.initActive = true;
	}

	protected override void SetStartingValues ()
	{
		FindSmallGuy();
	}

	public override void Execute ()
	{
		if( rb == null){
			if( !IsInvoking( "AddRigidBody" ) && !properties.GetPropertyBoolean( "die" ) )
				Invoke( "AddRigidBody" , 0.8f );
			return;
		}

		float sx = properties.GetPropertyNumber( "sx" );
		float psx= properties.GetPropertyNumber( "onplatform" );
		float sy = rb.velocity.y;

		rb.velocity = new Vector2 (0, sy);
		transform.position += new Vector3 (sx + psx, 0, 0) * Time.deltaTime;

		if( properties.GetPropertyBoolean( "down" ) ){
			SetPassiveLayer();
			layersSleep = true;
			Invoke ( "LayersWakeUp" , 0.1f );
		}

		if( !layersSleep )
			HandlePhysicsLayers();
	}

	private void FindSmallGuy(){
		GameObject sg = GameObject.FindGameObjectWithTag( "SmallGuy" );
		if( sg != null )
			smallGuy = sg.transform;
	}

	private void AddRigidBody(){
		rb = gameObject.AddComponent<Rigidbody2D>();
		rb.gravityScale = 6;
		rb.fixedAngle = true;
	}

	private void HandlePhysicsLayers(){
		if( smallGuy == null ){
			FindSmallGuy();
		}

		bool passiveLayer = smallGuy == null || 
						(smallGuy.position.y < transform.position.y + 0.8f ||
						(smallGuy.GetComponent<Rigidbody2D> () != null && smallGuy.GetComponent<Rigidbody2D> ().velocity.y > 1));

		if( passiveLayer ) SetPassiveLayer();
		else SetActiveLayer();
		
	}

	private void LayersWakeUp(){
		layersSleep = false;
	}

	private void SetPassiveLayer(){
		gameObject.layer = 10;
	}

	private void SetActiveLayer(){
		gameObject.layer = 8;
	}
}













