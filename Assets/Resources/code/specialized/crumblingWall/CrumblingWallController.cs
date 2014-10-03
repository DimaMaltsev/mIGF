using UnityEngine;
using System.Collections;

public class CrumblingWallController : MonoBehaviour {

	private float crumbleDelay = 0.25f;

	private void Crumble(){
		// TODO: emmit particle system
		Destroy( gameObject ); 
	}

	private void OnTriggerEnter2D(Collider2D other){
		if( other.tag != "BigGuy" ) return;

		if( !IsInvoking( "Crumble") )
			Invoke( "Crumble" , crumbleDelay );
	}
}
