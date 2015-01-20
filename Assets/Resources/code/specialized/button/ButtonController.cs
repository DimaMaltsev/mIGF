using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonController : MonoBehaviour {

	private List<Collider2D> contactors = new List<Collider2D>();

	private bool pressed = false;
	private Animator animator;
	private Activator activator;

	void Awake(){
		activator = GetComponent<Activator>();
		animator = GetComponent<Animator>();
		InitPolygonCollier();
	}

	void Update(){
		for(int i = 0; i < contactors.Count; i++){
			if(contactors[i] == null){
				contactors.RemoveAt(i);
				i--;

				if(contactors.Count == 0 )
					UnPress();
			}
		}
	}

	public void OnTriggerEnter2D( Collider2D other ){
		if( !ValidatePress( other ) ) return;
		contactors.Add (other);

		if( !pressed )
			Press();
	}

	public void OnTriggerExit2D( Collider2D other ){
		if( !ValidatePress( other ) ) return;
		contactors.Remove (other);

		if( !pressed || contactors.Count == 0 )
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
		return 
			other.GetComponent<Animation_BigGuy>() != null ||
			other.GetComponent<Jump_SmallGuy>() != null ||
				other.GetComponent<Box_Moves>() != null;
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
