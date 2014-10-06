using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {
	public Sprite ButtonUp;
	public Sprite ButtonDown;

	private bool pressed = false;
	private SpriteRenderer spriteRenderer;
	private Activator activator;

	void Awake(){
		spriteRenderer = GetComponent<SpriteRenderer>();
		activator = GetComponent<Activator>();
	}

	public void OnTriggerEnter2D( Collider2D other ){
		if( pressed || !ValidatePress( other ) ) return;
		Press();
	}

	public void OnTriggerExit2D( Collider2D other ){
		pressed = false;
		spriteRenderer.sprite = ButtonUp;
	}

	private void Press(){
		pressed = true;
		spriteRenderer.sprite = ButtonDown;
		activator.Activate();
	}

	private bool ValidatePress( Collider2D other ){
		return true;
	}
}
