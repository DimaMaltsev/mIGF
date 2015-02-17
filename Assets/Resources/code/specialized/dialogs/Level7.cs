using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level7 : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}	
			new string[]{	"Ti"	, "It's them", "happy"},		
			new string[]{	"Ti"	, "Can you hear!?", "normal"},		
			new string[]{	"Ti"	, "They're right below us!", "normal"},		
			new string[]{	"Ti"	, "Not above us: there is only sky!", "normal"},
			new string[]{	"Ti"	, "Below!", "neutral"},
			new string[]{	"Ti"	, "We've almost caught them up!", "normal"},
			new string[]{	"Ti"	, "Run, Gwo, run!", "neutral"},
			
			new string[]{	"Gwo"	, "What? Little men? Finally!", "normal"},
			new string[]{	"Gwo"	, "I am starting to feel myself hungry", "happy"},
			
			new string[]{	"Ti"	, "We don't need food, Gwo!", "neutral"},
			new string[]{	"Gwo"	, "So you think!", "normal"},
			new string[]{	"Gwo"	, "What about the spiritual, ritual component of the food?", "happy"},

			new string[]{	"Ti"	, "In the name of Laytvil", "normal"},
			new string[]{	"Ti"	, "whatever you say!", "neutral"},
			new string[]{	"Ti"	, "Run, we can't lose them again!", "angry"}
		};
		base.cameraShift = startCameraShift;
	}
}
