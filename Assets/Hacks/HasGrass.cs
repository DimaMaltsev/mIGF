using UnityEngine;
using System.Collections;

public class HasGrass : MonoBehaviour {
	public float grassProbability = 20f;

	public Sprite[] grassSprites;

	private SpriteRenderer grassSprite;

	void Start(){
		GameObject grass = new GameObject ();
		grassSprite = grass.AddComponent<SpriteRenderer> ();
		grass.transform.parent = transform;
		grass.transform.position = Vector3.zero;
		grass.transform.localPosition = Vector3.up * 1.43f;
	}

	public void AddGrass(){
		Sprite sr = null;
		if( Random.Range( 0, 100 ) < grassProbability )
			sr = grassSprites [Random.Range(0,grassSprites.Length)];
		grassSprite.sprite = sr;
	}
}
