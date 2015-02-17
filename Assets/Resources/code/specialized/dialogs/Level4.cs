using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level4 : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}
			new string[]{	"Gwo"	, "I was thinking...", "normal"},			
			new string[]{	"Ti"	, "Wow!", "normal"},
			
			new string[]{	"Gwo"	, "Otanis - all but rectangle", "normal"},
			new string[]{	"Gwo"	, "Think - rectangle in space!", "normal"},
			new string[]{	"Gwo"	, "And it illuminates by the shard of one of the tears of...", "normal"},
			new string[]{	"Gwo"	, "...the gigantic infant", "normal"},
			new string[]{	"Gwo"	, "The tear that has once torn to pieces the whole planet...", "normal"},
			new string[]{	"Gwo"	, "It all looks fishily", "neutral"},
			
			new string[]{	"Ti"	, "Truth is yours", "normal"},
			new string[]{	"Ti"	, "Let's say...", "normal"},
			new string[]{	"Ti"	, "Did you see Otanis from afar?", "normal"},
			new string[]{	"Ti"	, "Me either", "neutral"},
			new string[]{	"Ti"	, "Then how could we know it's plane?", "normal"},
			new string[]{	"Ti"	, "The whole scape is plane?", "normal"},
			new string[]{	"Ti"	, "Otanis might be round, you know", "neutral"},
			
			new string[]{	"Gwo"	, "I am sure, men with such thoughts would be...", "neutral"},
			new string[]{	"Gwo"	, "...burnt among humans...", "normal"},
			
			new string[]{	"Ti"	, "Yep, since they are savages", "normal"},
			new string[]{	"Ti"	, "believe in all sorts of nonsense", "normal"},
			new string[]{	"Ti"	, "which haven't been seen by anyone of them...", "neutral"}
		};
		base.cameraShift = startCameraShift;
	}
}
