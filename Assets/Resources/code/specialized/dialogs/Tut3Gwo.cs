using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tut3Gwo : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}All-knowing stone.
			new string[]{	"Gwo"	, "Spikes? But they are spiny!", "neutral"},
			new string[]{	"Gwo"	, "I am too tender for spikes!", "sad"},
			new string[]{	"Gwo"	, "Hey, stones, is it yours doing!?", "neutral"},
			new string[]{	"Gwo"	, "Ti would show you!", "angry"},
			new string[]{	"Gwo"	, "By the way, where is he?", "neutral"},
			new string[]{	"Gwo"	, "Oh, yes, I am looking for him...", "sad"}
		};
		base.cameraShift = startCameraShift;
	}
}
