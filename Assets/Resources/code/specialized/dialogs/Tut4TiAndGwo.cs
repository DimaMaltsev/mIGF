using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tut4TiAndGwo : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}
			
			new string[]{	"Ti"	, "Did I ever tell you, I'm afraid of closed space?", "sad"},
			new string[]{	"Gwo"	, "Me either...", "sad"},
			new string[]{	"Ti"	, "Oh, lovely.", "neutral"}
		};
		base.cameraShift = startCameraShift;
	}
}
