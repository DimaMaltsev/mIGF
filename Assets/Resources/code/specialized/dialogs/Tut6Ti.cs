using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tut6Ti : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}
			new string[]{	"Ti"	, "Oh, I smell Gwo!", "normal"},
			new string[]{	"Ti"	, "Lord, a bath would do him good, it's horrible!", "sad"},
			new string[]{	"Ti"	, "At this rate, we will never reach the humans...", "sad"},
			new string[]{	"Ti"	, "...they will plainly quicken themselves...", "neutral"},
			new string[]{	"Ti"	, "...twenty times as soon as they smell Gwo's odor!", "angry"},
			new string[]{	"Ti"	, "I'd better hurry up!", "normal"},
		};
		base.cameraShift = startCameraShift;
	}
}
