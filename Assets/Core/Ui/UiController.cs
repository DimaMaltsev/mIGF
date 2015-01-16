using UnityEngine;
using System.Collections;

public class UiController : MonoBehaviour {

	public int uiSpriteOrderShift;

	private Camera camera;

	public Transform uiHolder;

	void Awake(){
		camera = GameObject.FindGameObjectWithTag ("MainCamera").camera;
		transform.parent = camera.transform;
		transform.position = Vector3.zero;
		RiseChildsSpritesOnTop ();
	}
	
	void Update () {
	
	}

	private void RiseChildsSpritesOnTop(){
		Transform parent = uiHolder == null ? transform : uiHolder.transform;
		int childCount = parent.childCount;
		for(int i = 0; i < childCount; i++){
			Transform child = parent.GetChild(i);
			SpriteRenderer sr = child.GetComponent<SpriteRenderer>();

			if(sr == null) continue;
			sr.sortingOrder += uiSpriteOrderShift;
		}
	}
}
