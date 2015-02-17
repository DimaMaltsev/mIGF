using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tut1Ti : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}
			new string[]{	"Ti"	, "What the heck, Gwo, where are you!?", "angry"},
			new string[]{	"Ti"	, "In the name of Laytvil, that healthy fellow is despairing", "angry"},
			new string[]{	"Ti"	, "lost out of the blue again!", "angry"},
			new string[]{	"Ti"	, "Okay, I'm cool enough to find him!", "normal"},
			new string[]{	"Ti"	, "Yeah... Enough...", "neutral"},

			
			new string[]{	"Ti"	, "Anyway, moving with arrows, jumping with S-P-A-C-E button", "normal"},
			new string[]{	"Ti"	, "Also we have a double jump - double press on space..", "normal"},
			new string[]{	"Ti"	, "as you can easily guess...", "neutral"},
			new string[]{	"Ti"	, "Who on earth am I talking to!?", "neutral"},
			new string[]{	"Ti"	, "I'm sure it's all because of that frownmushroom", "normal"},
			new string[]{	"Ti"	, "It's boring to walk by foot...", "normal"},
			new string[]{	"Ti"	, "so I'll be travelling through the tunnels", "normal"},
			new string[]{	"Ti"	, "There is an entrance, by the way. Let's go!", "happy"}


		};
		base.cameraShift = startCameraShift;
	}
}
