using UnityEngine;
using System.Collections;

public class Physics_BigGuy : Interface {

	private Rigidbody2D rb;
	private Transform smallGuy;

	public Physics_BigGuy() : base( "sx" , "die"){
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
				Invoke( "AddRigidBody" , 1.1f );
			return;
		}

		float sx = properties.GetPropertyNumber( "sx" );
		float sy = rb.velocity.y;

		rb.velocity = new Vector2 ( sx , sy );

		HandlePhysicsLayers();
	}

	private void FindSmallGuy(){
		GameObject sg = GameObject.FindGameObjectWithTag( "SmallGuy" );
		if( sg != null )
			smallGuy = sg.transform;
	}

	private void AddRigidBody(){
		rb = gameObject.AddComponent<Rigidbody2D>();
		rb.gravityScale = 4;
		rb.fixedAngle = true;
	}

	private void HandlePhysicsLayers(){
		if( smallGuy == null ){
			FindSmallGuy();
		}

		if( smallGuy == null || smallGuy.position.y < transform.position.y + 0.5f ){
			gameObject.layer = 10;
		}else{
			gameObject.layer = 8;
		}
	}
}













