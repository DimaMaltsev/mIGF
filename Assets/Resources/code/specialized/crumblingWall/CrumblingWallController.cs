﻿using UnityEngine;
using System.Collections;

public class CrumblingWallController : MonoBehaviour {

	private float crumbleDelay = 0.45f;

	private void Crumble(){
		// TODO: emmit particle system
		Destroy( gameObject ); 
	}

	private void OnTriggerEnter2D(Collider2D other){
		print ("asda");
		if( other.tag != "BigGuy" && other.tag != "Box" ) return;

		if( !IsInvoking( "Crumble") )
			Invoke( "Crumble" , crumbleDelay );
	}
}
