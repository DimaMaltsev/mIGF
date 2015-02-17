using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tut4Gwo : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}All-knowing stone.
			new string[]{	"Gwo"	, "I am sure, I can lift up this wall by force of thought"}
		};
		base.cameraShift = startCameraShift;
	}
}
