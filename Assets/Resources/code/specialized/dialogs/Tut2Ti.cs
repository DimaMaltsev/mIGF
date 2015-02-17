using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tut2Ti : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}
			new string[]{	"Ti"	, "The main thing is not to fall", "normal"},
			new string[]{	"Ti"	, "And why this forest is so...", "neutral"},
			new string[]{	"Ti"	, "Well, like if it isn't a forest at all", "neutral"},
			new string[]{	"Ti"	, "I always say, it doesn't remember how it should look like..", "neutral"},
			new string[]{	"Ti"	, "...because of the...", "neutral"},
			new string[]{	"Ti"	, "Tear's energy!", "happy"},
			new string[]{	"Ti"	, "Gwo isn't here, so I'll walk on...", "neutral"}




		};
		base.cameraShift = startCameraShift;
	}
}
