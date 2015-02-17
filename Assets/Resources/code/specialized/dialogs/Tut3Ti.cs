using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tut3Ti : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}
			new string[]{	"Ti"	, "These things are even moving!", "neutral"},
			new string[]{	"Ti"	, "Do they want me to fall?", "angry"},
			new string[]{	"Ti"	, "For cereal?", "neutral"},
			new string[]{	"Ti"	, "Oh, my...", "sad"}
		};
		base.cameraShift = startCameraShift;
	}
}
