using UnityEngine;
using System.Collections;

public class Camera_mockupMenu : MonoBehaviour {
	public string[] levels;

	void Start(){
		LoadLevel ();
	}

	private void LoadLevel(){
		Messenger.Broadcast<string[]>( "LoadState" , GetCurrentStateAndNextState() );
	}

	private string[] GetCurrentStateAndNextState(){
		string currentState = GameObject.FindGameObjectWithTag ("StatesManager").GetComponent<StatesManager> ().currentState;
		string loadState = "";
		string nextState = "";

		int index = 0;
		for(int i = 0 ; i < levels.Length; i++ ){
			if( currentState == levels[i] ){
				index = i;
				break;
			}
		}

		loadState = levels [index+1];
		if( index + 2 < levels.Length )
			nextState = levels[index + 2];
		else
			nextState = "";

		return  new string[]{loadState, nextState};
	}
}
