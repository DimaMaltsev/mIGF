using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tut1TiAndGwo : CutSceneTrigger {
	public Vector2 startCameraShift;
	void Awake(){
		dialog = new List<string[]>{ // possible emotions {"sad", "happy", "angry", "neutral"}
			new string[]{	"Ti"	, "At long last!", "angry"},
			new string[]{	"Ti"	, "Where the heck have you been!?", "angry"},
			new string[]{	"Ti"	, "I've really got tired while I was looking for you!", "neutral"},

			new string[]{	"Gwo"	, "Ti! My little fellow!", "happy"},
			new string[]{	"Gwo"	, "Where did you hide?", "neutral"},
			
			new string[]{	"Ti"	, "What!? Where did YOU hide!", "angry"},
			new string[]{	"Ti"	, "While you've been collecting that rootlets and mushrooms of yours...", "neutral"},
			new string[]{	"Ti"	, "...people must have already hidden Tear!", "neutral"},		
			new string[]{	"Ti"	, "Oh, no, I'm right. everything's doomed!", "neutral"},
			new string[]{	"Ti"	, "It's all your fault!", "neutral"},

			new string[]{	"Gwo"	, "Hey, I have super power", "happy"},
			new string[]{	"Gwo"	, " I am superspirit, I was certainly chosen by Laytvil himself", "neutral"},

			new string[]{	"Ti"	, "WILL YOU EVER listen to me!?...", "angry"},
			new string[]{	"Ti"	, "WHAT!?", "angry"},
			new string[]{	"Ti"	, "What did you eat, what super powers!?", "neutral"},
			new string[]{	"Ti"	, "Hey! Humans! Tear!", "neutral"},
			new string[]{	"Ti"	, "Have you forgotten where and why we were going?", "neutral"},

			new string[]{	"Gwo"	, "Well... Tear... Humans... Stolen... Yes", "neutral"},

			new string[]{	"Ti"	, "Lord, you are despairing!", "sad"},
			new string[]{	"Ti"	, "With you any drama can't be felt!", "neutral"},
			new string[]{	"Ti"	, "How am I supposed to become an actor with such a partner?", "sad"},
						
			new string[]{	"Gwo"	, "Ahem... What are you talking about?", "neutral"},
			
			new string[]{	"Ti"	, "Never mind!", "neutral"},
			new string[]{	"Ti"	, "Come on, let me take a jump on your back", "happy"},
			new string[]{	"Ti"	, "I'll check what's up there...", "happy"},
			new string[]{	"Ti"	, "And remember - we're moving synchronously!", "neutral"},
			new string[]{	"Ti"	, "I'm taking a step - you're taking a step!", "neutral"},
			new string[]{	"Ti"	, "Hope, at least this way you won't get yourself lost...", "neutral"},
			
			new string[]{	"Gwo"	, "Yes, yes, as you say, just stop yelling...", "normal"}


		};
		base.cameraShift = startCameraShift;
	}
}
