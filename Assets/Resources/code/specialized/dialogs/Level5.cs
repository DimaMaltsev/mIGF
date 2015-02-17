using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level5 : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}
			new string[]{	"Gwo"	, "Are you sure that humans have passed here?", "normal"},			
			new string[]{	"Ti"	, "No", "normal"},
			
			new string[]{	"Gwo"	, "So why then we should pass this place?", "neutral"},
			new string[]{	"Gwo"	, "I can see spikes and all the stuff...", "normal"},
			
			new string[]{	"Ti"	, "Do you have any better options?", "neutral"},
			
			new string[]{	"Gwo"	, "Well, we might...", "neutral"},
			
			new string[]{	"Ti"	, "Excellent, no questions, then let's go!", "neutral"},
			new string[]{	"Gwo"	, "Oh, Lord... Episode Four: Silly Hope...", "sad"},
			new string[]{	"Gwo"	, "Let's go...", "sad"},
		};
		base.cameraShift = startCameraShift;
	}
}
