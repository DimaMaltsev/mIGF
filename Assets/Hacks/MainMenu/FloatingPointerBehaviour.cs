using UnityEngine;
using System.Collections;

public class FloatingPointerBehaviour : MonoBehaviour {
	public float floatShift = 1;

	private float[] positions = new float[2];
	private int currentFloatIndex = 0;
	void Awake(){
		positions [0] = transform.position.y - floatShift;
		positions [1] = transform.position.y + floatShift;

		transform.position = new Vector3( transform.position.x, positions [1], transform.position.z );
	}

	void Update () {
		if( Mathf.Abs(transform.position.y - positions[currentFloatIndex]) < 0.01f ){
			transform.position = new Vector3( transform.position.x, positions [currentFloatIndex], transform.position.z );
			currentFloatIndex = 1 - currentFloatIndex;
		}else{
			transform.position = Vector3.Lerp ( transform.position , new Vector3( transform.position.x, positions [currentFloatIndex], transform.position.z ), Time.deltaTime * 10);
		}

	}
}
