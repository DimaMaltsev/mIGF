using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tut1TiAndGwo1 : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}

			new string[]{	"Gwo"	, "Did you see!?", "happy"},

			
			new string[]{	"Ti"	, "What!?", "neutral"},

			new string[]{	"Gwo"	, "I moved it! I lifted up the wall!", "happy"},

			new string[]{	"Ti"	, "No, I've just... ", "neutral"},
			new string[]{	"Ti"	, "Ah, to hell with it, let's go already!", "angry"},
			new string[]{	"Ti"	, "In the tunnels synchronously too, don't forget!", "neutral"}


		};
		base.cameraShift = startCameraShift;
	}
}
