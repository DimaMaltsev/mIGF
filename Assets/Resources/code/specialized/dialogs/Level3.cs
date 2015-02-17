using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level3 : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}
			new string[]{	"Gwo"	, "Did not you ever feel like you are leading into a trap?", "neutral"},			
			new string[]{	"Ti"	, "No, why?", "normal"},
			new string[]{	"Gwo"	, "Nothing, I said it by the way", "normal"}
		};
		base.cameraShift = startCameraShift;
	}
}
