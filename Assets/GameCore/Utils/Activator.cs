using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour {
	public Transform toActivate;

	public void Activate(){
		if( toActivate == null ) return;
		toActivate.SendMessage( "ActivateTrigger" , SendMessageOptions.DontRequireReceiver );
	}
}
