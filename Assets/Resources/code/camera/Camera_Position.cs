using UnityEngine;
using System.Collections;

public class Camera_Position : MonoBehaviour {
	private Transform bigGuy;
	private Transform smallGuy;

	private float maxZoom = 4;
	private float minZoom = 1;
	private float curZoom;

	private Camera camera;

	void Awake(){
		camera = GetComponent<Camera>();
		curZoom = minZoom;
	}

	void Update () {
		if( bigGuy == null || smallGuy == null ){
			FindGuys();
			return;
		}
		UpdateZoom();


		Vector3 pos = ( bigGuy.position + smallGuy.position ) / 2 - Vector3.forward * 10;

		transform.position = Vector3.Lerp( transform.position , pos , Time.deltaTime * 10 );
		//camera.orthographicSize = Mathf.Lerp( camera.orthographicSize , curZoom , Time.deltaTime * 10 );
	}

	private void FindGuys(){
		GameObject bg = GameObject.FindGameObjectWithTag( "BigGuy" );
		GameObject sg = GameObject.FindGameObjectWithTag( "SmallGuy" );

		bigGuy 		= bg == null ? null : bg.transform;
		smallGuy 	= sg == null ? null : sg.transform;
	}

	private void UpdateZoom(){
		if( !bigGuy.GetComponent<SpriteRenderer>().isVisible || !smallGuy.GetComponent<SpriteRenderer>().isVisible ){
			curZoom += 0.1f;
		}
	}
}
