using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level2 : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}
			new string[]{	"Ti"	, "Smells like frownmushroom!", "happy"},

			new string[]{	"Gwo"	, "Indeed", "normal"},
			
			new string[]{	"Ti"	, "Unlike you, I know their use isn't only in being eaten...", "neutral"},

			new string[]{	"Gwo"	, "Oh, come on, you eat them not less than me!", "neutral"},

			new string[]{	"Ti"	, "Silence!", "neutral"},
			new string[]{	"Ti"	, "What I'm talking about is that it's also really cool to jump on them!", "normal"},

			new string[]{	"Gwo"	, "And what if I will crush anyone of them?", "neutral"},
			new string[]{	"Gwo"	, "I do not want to become a murderer!", "sad"},
			new string[]{	"Gwo"	, "And I...", "neutral"},

			new string[]{	"Ti"	, "Yeah, yeah, yeah", "neutral"},
			new string[]{	"Ti"	, "a pit, a little rootlet per a day, date once a month", "neutral"},
			new string[]{	"Ti"	, "blah blah blah...", "neutral"},
			new string[]{	"Ti"	, "Don't be afraid, nobody will know", "normal"},
			
			new string[]{	"Gwo"	, "Hey, Ti, I warned you!..", "neutral"},
			new string[]{	"Gwo"	, "This mushroom would better not die...", "normal"}


		};
		base.cameraShift = startCameraShift;
	}
}
