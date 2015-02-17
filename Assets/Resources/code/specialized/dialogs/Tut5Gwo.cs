using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tut5Gwo : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}All-knowing stone.
			new string[]{	"Gwo"	, "I wonder if I can break walls with my indomitable power?", "neutral"},
			new string[]{	"Gwo"	, "No question!", "angry"}
		};
		base.cameraShift = startCameraShift;
	}
}
