using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tut5Ti : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}
			new string[]{	"Ti"	, "I might be wrong, but it seems to me that...", "normal"},
			new string[]{	"Ti"	, "these tunnels have been intentionally placed in places like this!", "neutral"},
			new string[]{	"Ti"	, "Can't the exits NOT lead to precipices!?", "neutral"}
		};
		base.cameraShift = startCameraShift;
	}
}
