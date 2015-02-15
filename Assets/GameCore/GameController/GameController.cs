using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private int waitingForObjectsCount = 0;
	private int objectsReachedEndCount = 0;
	private bool levelEnded = false;

	void Start(){
		Messenger.AddListener( "GuyReachedEndPoint" , OnGuyReachedEndPoint	);
		Messenger.AddListener( "GuyLeavedEndPoint" 	, OnGuyLeavedEndPoint 	);

		if( GameObject.FindGameObjectWithTag( "SmallGuySpawner" ) 	!= null ) waitingForObjectsCount++;
		if( GameObject.FindGameObjectWithTag( "BigGuySpawner" ) 	!= null ) waitingForObjectsCount++;

	}

	void OnGUI(){
		if(objectsReachedEndCount != waitingForObjectsCount && !Input.GetButton("Esc") ) return;

		GUIStyle centeredStyle2 = GUI.skin.GetStyle("Button");
		if(GUI.Button (new Rect (Screen.width/2 - 50, Screen.height/2 - 25, 100, 50), "NEXT LEVEL", centeredStyle2)){			
			Messenger.Broadcast<string[]>( "LoadState" , new string[]{} );
		}
		if(GUI.Button (new Rect (Screen.width/2 - 50, Screen.height/2 + 25, 100, 50), "MAP", centeredStyle2)){			
			Messenger.Broadcast<string[]>( "LoadState" , new string[]{"map"} );
		}
	}

	private void OnGuyReachedEndPoint(){ objectsReachedEndCount++; FinishGame(); }
	private void OnGuyLeavedEndPoint(){ objectsReachedEndCount--; }

	private void StartGame(){}

	private void FinishGame(){
		if( objectsReachedEndCount != waitingForObjectsCount ) return;
	}
}
