using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level1 : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}
			new string[]{	"Ti"	, "Finally!", "neutral"},
			new string[]{	"Ti"	, "We've got on their trail!", "angry"},

			new string[]{	"Gwo"	, "Whose?", "neutral"},
			
			new string[]{	"Ti"	, "Humans, who else!", "neutral"},

			new string[]{	"Gwo"	, "Er, I don't see any little men here...", "neutral"},

			new string[]{	"Ti"	, "Hell, that's why I'm saying we've got on the trail, not caught up!", "angry"},
			new string[]{	"Ti"	, "Capisce?", "neutral"},

			new string[]{	"Gwo"	, "Okay, okay, as you say", "neutral"},

			new string[]{	"Ti"	, "Then get yourself into this strange hole in the ground!", "angry"},
			new string[]{	"Ti"	, "They most probably there!", "neutral"}


		};
		base.cameraShift = startCameraShift;
	}
}
