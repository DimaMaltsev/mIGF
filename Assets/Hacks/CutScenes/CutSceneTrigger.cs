using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CutSceneTrigger : MonoBehaviour {

	protected List<string[]> dialog = new List<string[]>();

	private bool dialogShown = false;
	
	public void OnTriggerEnter2D(Collider2D c){
		if( c.GetComponent<Jump_SmallGuy>() == null && c.GetComponent<Collider_BigGuy>() == null || dialogShown) return;
		Messenger.Broadcast<List<string[]>> ("CutSceneTrigger", dialog);
		dialogShown = true;
	}
}
