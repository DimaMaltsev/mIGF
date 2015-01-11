using UnityEngine;
using System.Collections;

public class ParalaxController : MonoBehaviour {
	private Camera camera;
	private Vector3 lastCameraPosition;
	private float z;
	private float y;


	public float paralaxSpeedAffector;
	public float yShift;
	public Transform[] movingLayers;

	void Awake () {
		camera = GameObject.FindGameObjectWithTag("MainCamera").camera;
		z = transform.position.z;
		y = transform.position.y;

		CopyCameraPosition ();
	}

	void Update () {
		Vector3 diff = camera.transform.position - lastCameraPosition;
		if( diff.magnitude != 0 ){
			CameraMoved(diff);
			CopyCameraPosition ();
		}
	}

	private void CopyCameraPosition(){
		transform.position = new Vector3( camera.transform.position.x , camera.transform.position.y + yShift, z );
		lastCameraPosition = camera.transform.position;
	}

	private void CameraMoved(Vector3 diff){
		for(int i = 0 ; i < movingLayers.Length ; i++ ){
			movingLayers[i].GetComponent<ParalaxLevelController>().CameraMove(diff);
		}
	}
}
