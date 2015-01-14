using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CutScenesController : MonoBehaviour {

	public float letterShowDelay = 1;

	public Transform upLine;
	public Transform downLine;
	public Transform text;
	public Transform avatar;

	private SpriteRenderer upSprite;
	private SpriteRenderer downSprite;
	private TextMesh textMesh;
	private SpriteRenderer avatarSprite;

	private float currentAlpha = 0;
	private List<string[]> currentDialog = new List<string[]>();
	private int currentLetterIndex;
	private bool phraseIsPrinting = false;
	private bool sceneIsOn = false;

	void Awake(){
		upSprite 	= upLine.GetComponent<SpriteRenderer> ();
		downSprite 	= downLine.GetComponent<SpriteRenderer> ();
		avatarSprite= avatar.GetComponent<SpriteRenderer> ();

		textMesh = text.GetComponent<TextMesh> ();

		upSprite.color = new Color (1, 1, 1, currentAlpha);
		downSprite.color = new Color (1, 1, 1, currentAlpha);
		avatarSprite.color = new Color (1, 1, 1, currentAlpha);
		textMesh.color = new Color (1, 1, 1, currentAlpha);
		
		
		Messenger.AddListener<List<string[]>> ("CutSceneTrigger", ShowCutScene);
	}
	
	void Update () {
		float a = upSprite.color.a;
		if( a != currentAlpha ){
			float newAlpha = Mathf.Lerp( a, currentAlpha, Time.deltaTime * 10 );
			upSprite.color = new Color (1, 1, 1, newAlpha );
			downSprite.color = new Color (1, 1, 1, newAlpha);
			avatarSprite.color = new Color (1, 1, 1, newAlpha);
			textMesh.color = new Color (1, 1, 1, newAlpha);
		}

		if (!sceneIsOn) {
			return;		
		}

		if( Input.GetButtonDown("Jump") ){
			if( phraseIsPrinting ){
				if( IsInvoking( "ShowNextLetter" ) )
					CancelInvoke("ShowNextLetter");
				textMesh.text = currentDialog[ 0 ][ 0 ] + " : " + currentDialog[ 0 ][ 1 ];
				currentLetterIndex = currentDialog[ 0 ][ 1 ].Length;
				ShowNextLetter();
			}else{
				ShowNextPhrase();
			}
		}
	}

	private void ShowNextPhrase(){
		if(currentDialog.Count == 0){
			EndCutScene();
			return;
		}
		
		textMesh.text = "";

		currentLetterIndex = 0;
		textMesh.text = currentDialog [0] [0] + " : ";
		ShowNextLetter ();
	}

	private void ShowNextLetter(){
		if(currentLetterIndex >= currentDialog[0][1].Length){
			currentDialog.RemoveAt(0);
			phraseIsPrinting = false;
			textMesh.text += "\n..press space..";
			return;
		}

		phraseIsPrinting = true;

		textMesh.text += currentDialog [0] [1] [currentLetterIndex];
		currentLetterIndex++;

		Invoke ("ShowNextLetter", letterShowDelay);
	}

	private void ShowCutScene(List<string[]> dialog){
		if( dialog.Count == 0 ) return;
		sceneIsOn = true;
		currentDialog = dialog;
		currentAlpha = 1;
		ShowNextPhrase ();
		SendStartCutSceneMessage ();
	}

	private void EndCutScene(){
		sceneIsOn = false;
		currentAlpha = 0;
		Invoke ("SendEndCutSceneMessage", 1);
	}

	private void SendStartCutSceneMessage(){
		Messenger.Broadcast ("CutSceneStart");
	}

	private void SendEndCutSceneMessage(){
		Messenger.Broadcast ("CutSceneEnd");
	}
}
