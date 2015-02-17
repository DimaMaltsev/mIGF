using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tut5Gwo1 : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}All-knowing stone.
			new string[]{	"Gwo"	, "Yes!! Now there is no doubt that I am the chosen one!", "happy"},
			new string[]{	"Gwo"	, "I am going to save Tear from those funny creatures' hands!", "angry"}
		};
		base.cameraShift = startCameraShift;
	}
}
