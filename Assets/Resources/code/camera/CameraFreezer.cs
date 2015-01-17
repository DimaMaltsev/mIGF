using UnityEngine;
using System.Collections;

public class CameraFreezer : MonoBehaviour {
	public Vector2 cameraFreezePoint;
	public float unfreezeWaitTime = 1;

	private int intruders = 0;

	private void OnTriggerEnter2D(Collider2D c){
		if( !CountThis(c) ) return;

		if (IsInvoking ("SendUnFreeze"))
						CancelInvoke ("SendUnFreeze");

		intruders++;
		Messenger.Broadcast<Vector2> ("FreezeOnPoint", cameraFreezePoint);
	}

	private void OnTriggerExit2D(Collider2D c){
		if( !CountThis(c) ) return;
		intruders--;
		if(intruders==0){
			Invoke("SendUnFreeze", unfreezeWaitTime);
		}
	}

	private bool CountThis(Collider2D c){
		return c.GetComponent<Collider_BigGuy> () != null || c.GetComponent<Jump_SmallGuy> () != null;
	}

	private void SendUnFreeze(){		
		Messenger.Broadcast ("DeFreezeOnPoint");
	}
}
