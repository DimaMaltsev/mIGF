using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tut2Gwo : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}All-knowing stone.
			new string[]{	"Gwo"	, "Oh, there goes He!", "neutral"},
			new string[]{	"Gwo"	, "All-knowing stone", "neutral"},
			new string[]{	"Gwo"	, "He knows everything, but he will never say anything", "neutral"},
			new string[]{	"Gwo"	, "Probably, because of the fact that he is asleep...", "neutral"},
			new string[]{	"Gwo"	, "The entrance to the tunnel is too high...", "neutral"},
			new string[]{	"Gwo"	, "Maybe He will help me", "neutral"},
			new string[]{	"Gwo"	, "He is asleep anyway...", "neutral"},
		};
		base.cameraShift = startCameraShift;
	}
}
