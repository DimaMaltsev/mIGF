using UnityEngine;
using System.Collections;

public class UiController : MonoBehaviour {

	public int uiSpriteOrderShift;

	private Camera camera;

	void Awake(){
		camera = GameObject.FindGameObjectWithTag ("MainCamera").camera;
		transform.parent = camera.transform;
		transform.position = Vector3.zero;
		RiseChildsSpritesOnTop ();
	}
	
	void Update () {
	
	}

	private void RiseChildsSpritesOnTop(){
		int childCount = transform.childCount;
		for(int i = 0; i < childCount; i++){
			Transform child = transform.GetChild(i);
			SpriteRenderer sr = child.GetComponent<SpriteRenderer>();

			if(sr == null) return;
			sr.sortingOrder += uiSpriteOrderShift;
		}
	}
}
