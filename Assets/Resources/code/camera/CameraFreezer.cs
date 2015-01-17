using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFreezer : MonoBehaviour {
	public Vector2 cameraFreezePoint;
	public float unfreezeWaitTime = 1;

	private List<Transform> intruders = new List<Transform>();

	private void OnTriggerEnter2D(Collider2D c){
		if( !CountThis(c) ) return;

		if (IsInvoking ("SendUnFreeze"))
			CancelInvoke ("SendUnFreeze");

		intruders.Add(c.transform);
		Messenger.Broadcast<Vector2> ("FreezeOnPoint", cameraFreezePoint);
	}

	private void OnTriggerExit2D(Collider2D c){
		if( !CountThis(c) ) return;
		intruders.Remove (c.transform);
		CheckUnfreeze ();
	}

	private bool CountThis(Collider2D c){
		return c.GetComponent<Collider_BigGuy> () != null || c.GetComponent<Jump_SmallGuy> () != null;
	}

	void Update(){
		if( intruders.Count == 0 ) return;

		bool checkUnfreeze = false;
		for(int i = 0;i < intruders.Count;i++){
			if( intruders[i] == null){
				intruders.RemoveAt(i);
				i--;
				checkUnfreeze = true;
			}
		}
		if( checkUnfreeze )
			CheckUnfreeze();
	}

	private void CheckUnfreeze(){
		if(intruders.Count==0){
			Invoke("SendUnFreeze", unfreezeWaitTime);
		}
	}

	private void SendUnFreeze(){		
		Messenger.Broadcast ("DeFreezeOnPoint");
	}
}
