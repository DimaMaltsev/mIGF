using UnityEngine;
using System.Collections;

public class FinalWaiter : MonoBehaviour {
	public string GuyTag;
	private bool entered = false;

	private void OnTriggerEnter2D( Collider2D other ){
		if( entered || !IsValidCollider( other ) ) return;
		entered = true;
		Messenger.Broadcast( "GuyReachedEndPoint" );
	}

	private void OnTriggerExit2D( Collider2D other ){
		if( !entered || !IsValidCollider( other ) ) return;
		entered = false;
		Messenger.Broadcast( "GuyLeavedEndPoint" );
	}

	private bool IsValidCollider( Collider2D collider ){
		return collider.tag == GuyTag;
	}
}
