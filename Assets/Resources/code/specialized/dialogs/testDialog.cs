﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class testDialog : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}
			new string[]{	"Gwo"	, "Hi, bitch!"},
			new string[]{	"Gwo"	, "ssup?" , "angry"},
			new string[]{	"Gwo"	, "Wanna buy some weed?"},
			new string[]{	"Ti"	, "Ur u selling?"},
			new string[]{	"Gwo"	, "No"},
			new string[]{	"Gwo"	, "Catherine the Great was the most renowned and ..."},
			new string[]{	"Gwo"	, "... the longest-ruling female leader of Russia."},
			new string[]{	"Ti"	, "Ok, bye, bitch!"}
		};
		base.cameraShift = startCameraShift;
	}
}
