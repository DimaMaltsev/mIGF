using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour {
	public Transform[] toActivate;

	public void Activate(){
		if( toActivate == null ) return;

		for( int i = 0 ; i < toActivate.Length ; i++ ){
			Transform a = toActivate[ i ];
			if( a == null ) continue;
			Send( a , "ActivateTrigger" );
		}
	}

	public void DeActivate(){
		if( toActivate == null ) return;
		
		for( int i = 0 ; i < toActivate.Length ; i++ ){
			Transform a = toActivate[ i ];
			if( a == null ) continue;
			Send( a , "DeActivateTrigger" );
		}
	}

	private void Send( Transform a , string mess ) {
		a.SendMessage( mess, SendMessageOptions.DontRequireReceiver );
	}
}
