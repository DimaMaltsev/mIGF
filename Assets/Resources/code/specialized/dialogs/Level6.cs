using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level6 : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}
			new string[]{	"Gwo"	, "No! No more cavities! I will not go!", "sad"},			
			new string[]{	"Ti"	, "Come on, Gwo!", "normal"},		
			new string[]{	"Ti"	, "Soon we'll catch up the humans", "normal"},		
			new string[]{	"Ti"	, "return Tear and become heroes", "happy"},		
			new string[]{	"Ti"	, "They will emboss our faces on Tear, no doubt!", "normal"},
			
			new string[]{	"Gwo"	, "Hm...", "neutral"},
			new string[]{	"Gwo"	, "Will they carry rootlets and mushrooms to us?", "happy"},
			
			new string[]{	"Ti"	, "Yes, of cource!", "happy"},
			new string[]{	"Ti"	, "If they won't", "neutral"},
			new string[]{	"Ti"	, "I'll personally tear them to fourteen thousand airy spirits!", "normal"}
		};
		base.cameraShift = startCameraShift;
	}
}
