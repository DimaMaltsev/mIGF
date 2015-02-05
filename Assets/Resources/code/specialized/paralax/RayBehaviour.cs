using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RayBehaviour : MonoBehaviour {
	public float alphaChangeSpeed;
	public float rayLifeTime = 10;
	public float AddNewRayAlphaStep;
	public float FloatingSpeed = 0.1f;
	public Sprite raySprite;

	private float currentAlpha = 0;
	private float sign = 1;
	private List<GameObject> rays = new List<GameObject>();
	private float rayWidth = 0.25f;

	void Awake(){
		AddTwoRays ();
	}

	public void Iterate(){
		if (rayLifeTime <= 0) {			
			sign = -1;
		}

		if(currentAlpha < 0 ){
			Destroy(gameObject);
			return;
		}

		if (Mathf.Floor(currentAlpha / AddNewRayAlphaStep) >= rays.Count / 2) {
			AddTwoRays();
		}

		if (Mathf.Floor(currentAlpha / AddNewRayAlphaStep)  < rays.Count / 2 && currentAlpha > 0) {
			RemoveTwoRays();
		}

		transform.position += new Vector3 (FloatingSpeed, 0, 0) * Time.deltaTime;

		currentAlpha += sign * alphaChangeSpeed;
		rayLifeTime -= 0.01f;

		for(int i = 0 ; i < rays.Count; i++ ){
			SpriteRenderer spriteRenderer = rays[i].GetComponent<SpriteRenderer>();
			Color c = spriteRenderer.color;			
			spriteRenderer.color = new Color (c.r, c.b, c.g, c.a + sign * alphaChangeSpeed);
		}
	}

	private void RemoveTwoRays(){
		RemoveLastRay ();
		RemoveLastRay ();
	}

	private void RemoveLastRay(){
		
		Destroy (rays [rays.Count - 1]);
		rays.RemoveAt (rays.Count - 1);
	}

	private void AddTwoRays(){
		float x = rays.Count / 2 * rayWidth/2 + rayWidth/5;
		
		rays.Add (CreateSingleRay (x));
		rays.Add (CreateSingleRay (-x));
	}

	private GameObject CreateSingleRay(float x){
		GameObject ray = new GameObject ();
		ray.AddComponent<SpriteRenderer> ();
		ray.GetComponent<SpriteRenderer> ().sprite = raySprite;
		ray.GetComponent<SpriteRenderer> ().sortingOrder = -99;
		ray.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
		ray.transform.parent = transform;
		ray.transform.position = Vector3.zero;
		ray.transform.localPosition = new Vector3(x, 0, 0);
		return ray;
	}
}
