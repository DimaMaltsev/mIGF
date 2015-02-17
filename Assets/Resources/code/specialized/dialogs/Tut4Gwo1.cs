using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tut4Gwo1 : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}All-knowing stone.
			new string[]{	"Gwo"	, "I told you! I am invincible! I am superspirit! Right!"}
		};
		base.cameraShift = startCameraShift;
	}
}
