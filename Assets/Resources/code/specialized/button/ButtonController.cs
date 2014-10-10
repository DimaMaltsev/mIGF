using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {
	

	private bool pressed = false;
	private Animator animator;
	private Activator activator;

	void Awake(){
		activator = GetComponent<Activator>();
		animator = GetComponent<Animator>();
		InitPolygonCollier();
	}

	public void OnTriggerEnter2D( Collider2D other ){
		if( pressed || !ValidatePress( other ) ) return;
		Press();
	}

	public void OnTriggerExit2D( Collider2D other ){
		if( !pressed || !ValidatePress( other ) ) return;

		UnPress();
	}

	private void UnPress(){
		pressed = false;
		animator.SetBool( "pressed" , false );
		activator.DeActivate();
	}

	private void Press(){
		pressed = true;
		animator.SetBool( "pressed" , true );
		activator.Activate();
	}

	private bool ValidatePress( Collider2D other ){
		return true;
	}

	private void InitPolygonCollier(){
		PolygonCollider2D pc = GetComponent<PolygonCollider2D>();
		pc.points = new Vector2[]{
			new Vector2( -0.35f , 0 ),
			new Vector2( -0.45f , -0.08f ),
			new Vector2( 0.45f , -0.08f ),
			new Vector2( 0.345f , 0),
		};
	}
}
