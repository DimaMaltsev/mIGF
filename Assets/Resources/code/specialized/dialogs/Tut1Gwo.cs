using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tut1Gwo : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}
			new string[]{	"Gwo"	, "Ti?", "neutral"},
			new string[]{	"Gwo"	, "Hey, Ti, where are you?", "neutral"},
			new string[]{	"Gwo"	, "Oh, I think I got it: I lost myself", "normal"},
			new string[]{	"Gwo"	, "On the whole, someone lost himself for certain", "neutral"},
			new string[]{	"Gwo"	, "Yep", "normal"}
		};
		base.cameraShift = startCameraShift;
	}
}
