using UnityEngine;
using System.Collections;

public class Camera_mockupMap : MonoBehaviour {
	public string[] levels;

	void OnGUI(){
		if( levels == null ) return;
		
		for( int i = 0; i < levels.Length; i++ ){
			if( GUILayout.Button( levels[i] ) ){
				LoadLevel( GetCurrentStateAndNextState(levels[i]) );
			}
		}
		
	}

	private void LoadLevel(string[] states){
		Messenger.Broadcast<string[]>( "LoadState" , states );
	}

	private string[] GetCurrentStateAndNextState(string currentState){
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
