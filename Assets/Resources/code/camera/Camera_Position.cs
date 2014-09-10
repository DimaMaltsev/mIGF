using UnityEngine;
using System.Collections;

public class Camera_Position : MonoBehaviour {
	private Transform bigGuy;
	private Transform smallGuy;

	private Camera camera;

	void Awake(){
		camera = GetComponent<Camera>();
		Messenger.AddListener<Transform>( "SmallGuySpawned" , OnSmallGuySpawned );
		Messenger.AddListener<Transform>( "BigGuySpawned" 	, OnBigGuySpawned 	);
	}

	void Update () {
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
}
