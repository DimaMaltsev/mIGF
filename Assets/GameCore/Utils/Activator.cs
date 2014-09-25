using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Activator : MonoBehaviour {
	public Transform[] toActivate;

	public void Activate(){
		if( toActivate == null ) return;

		for( int i = 0 ; i < toActivate.Length ; i++ ){
			Transform a = toActivate[ i ];
			if( a == null ) continue;
			a.SendMessage( "ActivateTrigger" , SendMessageOptions.DontRequireReceiver );
		}
	}
}
