using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tut2TiAndGwo : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}

			new string[]{	"Gwo"	, "You know, if I am a spirit and...", "neutral"},
			new string[]{	"Gwo"	, "...at the same time I am big, black and strong", "neutral"},
			new string[]{	"Gwo"	, "Plus, I have super power...", "neutral"},
			new string[]{	"Gwo"	, "Then I am Batspirit!", "happy"},
			new string[]{	"Gwo"	, "And you are Trush!", "angry"},
			
			new string[]{	"Ti"	, "Whaaaat? Man, what are you talking about?", "neutral"},

			new string[]{	"Gwo"	, "Don't know, looks like those rootlets were stale...", "sad"},

			new string[]{	"Ti"	, "Come on...", "neutral"},
		};
		base.cameraShift = startCameraShift;
	}
}
