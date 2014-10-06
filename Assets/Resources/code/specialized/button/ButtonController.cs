using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {
	

	private bool pressed = false;
	private Animator animator;
	private Activator activator;

	void Awake(){
		activator = GetComponent<Activator>();
		animator = GetComponent<Animator>();
	}

	public void OnTriggerEnter2D( Collider2D other ){
		if( pressed || !ValidatePress( other ) ) return;
		Press();
	}

	public void OnTriggerExit2D( Collider2D other ){
		pressed = false;
		animator.SetBool( "pressed" , false );
	}

	private void Press(){
		pressed = true;
		animator.SetBool( "pressed" , true );
		activator.Activate();
	}

	private bool ValidatePress( Collider2D other ){
		return true;
	}
}
