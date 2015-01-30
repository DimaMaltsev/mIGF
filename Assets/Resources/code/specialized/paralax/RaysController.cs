using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RaysController : MonoBehaviour {
	public float RayMinEdgeSpawnDistance;
	public int MaxRaysCountInArea;
	public float RayAppearProbability;
	public float SecondsTillProbableNextRay;

	private List<RayBehaviour> rays = new List<RayBehaviour>();
	private bool createNewRay = true;

	void Update(){
		
		IterateRays ();

		if(IsInvoking("ShouldICreateANewRay")){
			return;
		}else{
			if(!createNewRay){
				return;
			}

			createNewRay = false;
			rays.Add(CreateRay().GetComponent<RayBehaviour>());
			Invoke ("ShouldICreateANewRay", SecondsTillProbableNextRay);
		}

	}

	private void IterateRays(){
		for(int i = 0 ; i < rays.Count; i++ ){
			if( rays[ i ] == null ){
				rays.RemoveAt( i );
				i--;
			}else{
				rays[i].Iterate();
			}
		}
	}

	private void ShouldICreateANewRay(){
		createNewRay = Random.Range(0.0f, 1.0f) < RayAppearProbability && MaxRaysCountInArea >= rays.Count;
	}

	private float GetRayPosition(){
		return (512 - RayMinEdgeSpawnDistance - Random.Range (0, 1024 - RayMinEdgeSpawnDistance))/84;
	}

	private GameObject CreateRay(){
		GameObject ray = (GameObject)Instantiate (Resources.Load ("Objects/Environment/ray"));
		ray.transform.parent = transform;
		ray.transform.position = Vector3.zero;
		ray.transform.localPosition = new Vector3 (GetRayPosition(), 5, 0);
		return ray;
	}
}
