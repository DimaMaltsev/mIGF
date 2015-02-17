using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tut4Ti : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}
			new string[]{	"Ti"	, "That guy just has to be here!", "normal"},
			new string[]{	"Ti"	, "Or there!", "neutral"},
			new string[]{	"Ti"	, "Hell, well, he has to be somewhere round here", "neutral"}
		};
		base.cameraShift = startCameraShift;
	}
}
