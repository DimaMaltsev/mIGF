using UnityEngine;
using System.Collections;

public class SpikeCollider : MonoBehaviour {

	private void OnTriggerEnter2D( Collider2D other ){
		if( other.GetComponent<Dieable>() == null ) return;
		if( other.GetComponent<Box_Moves>() != null ) return;

		other.GetComponent<Dieable>().Die();
	}
}
