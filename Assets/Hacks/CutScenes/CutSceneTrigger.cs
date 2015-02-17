using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CutSceneTrigger : MonoBehaviour {

	protected List<string[]> dialog = new List<string[]>();
	protected Vector2 cameraShift = Vector2.zero;

	private bool dialogShown = false;

	void Start(){
		string stateChangePurpose = GameObject.FindGameObjectWithTag ("StatesManager").GetComponent<StatesManager> ().levelStateChangePurpose;
		if (stateChangePurpose == "restart")
			dialogShown = true;
	}

	public void OnTriggerEnter2D(Collider2D c){
		if( c.GetComponent<Jump_SmallGuy>() == null && c.GetComponent<Collider_BigGuy>() == null || dialogShown) return;
		Messenger.Broadcast<List<string[]>,Vector2> ("CutSceneTrigger", dialog, cameraShift);
		dialogShown = true;
	}
}
