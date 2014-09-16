using UnityEngine;
using System.Collections;

public class BushController : MonoBehaviour {

	private Activator activator;
	public Animator animator;

	private float dieAnimationTime = 0.2f;

	void Awake(){
		activator = GetComponent<Activator>();
	}

	/*void Start(){
		DetectBushType();
	}*/

	public void OnTriggerEnter2D( Collider2D other ){
		BushTouched();
		GetComponent<BoxCollider2D>().enabled = false;
	}

	private void BushTouched(){
		TriggerActivator();
		Die();
	}

	private void TriggerActivator(){
		if( activator != null ) activator.Activate();
	}

	private void Die(){
		animator.enabled = true;
		Invoke( "DestroyGameObject" , dieAnimationTime );
	}

	private void DestroyGameObject(){
		Destroy( gameObject );
	}

	/*private void DetectBushType(){

	}*/
}
