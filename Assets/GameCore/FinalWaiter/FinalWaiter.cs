using UnityEngine;
using System.Collections;

public class FinalWaiter : MonoBehaviour {
	public string GuyTag = "SmallGuy";

	private void OnTriggerEnter2D( Collider2D other ){
		if( !IsValidCollider( other ) ) return;
		Messenger.Broadcast( "GuyReachedEndPoint" );
	}

	private void OnTriggerExit2D( Collider2D other ){
		if( !IsValidCollider( other ) ) return;
		Messenger.Broadcast( "GuyLeavedEndPoint" );
	}

	private bool IsValidCollider( Collider2D collider ){
		return collider.tag == GuyTag;
	}
}
