using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JumpMushroomController : MonoBehaviour {

	private List<Transform> justJumped = new List<Transform>();

	private Animator a;

	public float charactersJumpValue = 1000;
	public float boxJumpValue = 0.2f;

	void Awake(){
		a = GetComponent<Animator> ();
	}

	public void Jump( Transform jumper ){

		a.SetBool ("jump", true);

		justJumped.Add( jumper );

		LaunchBuddy( jumper );

		Invoke ( "RemoveJustJumped" , 0.2f );
		Invoke ("PreventJumpAnimationRepeat", 0.1f);
	}

	private void LaunchBuddy( Transform buddy ){


		if( buddy.GetComponent<Box_Moves>() == null ){
			Rigidbody2D rb = buddy.GetComponent<Rigidbody2D> ();
			rb.velocity = new Vector2( 0 , 0 );
			rb.AddForce( Vector2.up * charactersJumpValue );
			return;
		}

		buddy.GetComponent<ObjectController>().propertyFacade.SetProperty( "sy" , boxJumpValue );
	}

	private void RemoveJustJumped(){
		justJumped.RemoveAt( 0 );
	}

	private void PreventJumpAnimationRepeat(){
		a.SetBool ("jump", false);
	}

	private void OnTriggerEnter2D( Collider2D other ){
		if( !Launchable( other ) ) return;
		if( justJumped.Contains( other.transform ) ) return;

		float vy = GetVelocity( other );
		if( vy < -0.1 )
			Jump( other.transform );
	}

	private bool Launchable( Collider2D other ){
		bool small = other.GetComponent<Jump_SmallGuy> () != null;
		bool big = other.GetComponent<Jump_BigGuy> () != null;
		bool box = other.GetComponent<Box_Moves> () != null;

		return small || big || box;
	}

	private float GetVelocity( Collider2D jumper ){
		if( jumper.GetComponent<Box_Moves>() == null ) return jumper.GetComponent<Rigidbody2D>().velocity.y;

		return jumper.GetComponent<ObjectController>().propertyFacade.GetPropertyNumber( "sy" );
	}
}
