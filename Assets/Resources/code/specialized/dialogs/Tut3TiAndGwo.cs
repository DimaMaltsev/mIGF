using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tut3TiAndGwo : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}
			
			new string[]{	"Ti"	, "Pits again!?", "sad"},
			new string[]{	"Ti"	, "There is something wrong with this forest, I'm telling you!", "neutral"},

			new string[]{	"Gwo"	, "What?", "normal"},

			new string[]{	"Ti"	, "Telling, don't fall into the pit, big man!", "neutral"},
			new string[]{	"Ti"	, "Don't want to pull you out!", "neutral"},
			new string[]{	"Ti"	, "Again!", "angry"}
		};
		base.cameraShift = startCameraShift;
	}
}
