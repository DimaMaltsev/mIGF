using UnityEngine;
using System.Collections;

public class Camera_Position : MonoBehaviour {
	private Transform bigGuy;
	private Transform smallGuy;

	private Camera camera;
	private bool cameraFrozen = false;
	void Awake(){
		camera = GetComponent<Camera>();
		float red = Mathf.Floor(64000 / 255)/1000;
		float green = Mathf.Floor(79000 / 255)/1000;
		float blue = Mathf.Floor(61000 / 255)/1000;
		Color r = new Color (red, green, blue);
		camera.backgroundColor = r;///new Color (64/255,79/255,61/255);
		Messenger.AddListener<Transform>( "SmallGuySpawned" , OnSmallGuySpawned );
		Messenger.AddListener<Transform>( "BigGuySpawned" 	, OnBigGuySpawned 	);
		Messenger.AddListener<float>( "FreezeCamera" , OnFreezeCamera );
	}

	void Update () {
		if( cameraFrozen ) return;

		Vector3 pos = Vector3.zero;
		int coef = 0;
		if( bigGuy 		!= null ){ pos += bigGuy.position; 		coef ++; }
		if( smallGuy 	!= null ){ pos += smallGuy.position; 	coef ++; }
	
		if( coef == 0 ) return;

		Vector3 finalPos = pos / coef - Vector3.forward * 10;

		transform.position = Vector3.Lerp( transform.position , finalPos , Time.deltaTime * 10 );
	}

	private void OnSmallGuySpawned( Transform smallGuy ){
		this.smallGuy = smallGuy;
	}

	private void OnBigGuySpawned( Transform bigGuy ){
		this.bigGuy = bigGuy;
	}

	private void OnFreezeCamera( float time ){
		cameraFrozen = true;
		if( IsInvoking( "UnfreezeCamera" ) )
			CancelInvoke( "UnfreezeCamera" );
		Invoke ( "UnfreezeCamera" , time );
	}

	private void UnfreezeCamera(){
		cameraFrozen = false;
	}
}
