using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class testDialog : CutSceneTrigger {

	void Awake(){
		dialog = new List<string[]>{
			new string[]{	"Ti"	, "Hi, bitch!"},
			new string[]{	"Gwo"	, "ssup?"},
			new string[]{	"Gwo"	, "Wanna buy some weed?"},
			new string[]{	"Ti"	, "Ur u selling?"},
			new string[]{	"Gwo"	, "No"},
			new string[]{	"Gwo"	, "Catherine the Great was the most renowned and ..."},
			new string[]{	"Gwo"	, "... the longest-ruling female leader of Russia."},
			new string[]{	"Ti"	, "Ok, bye, bitch!"}
		};
	}
}
