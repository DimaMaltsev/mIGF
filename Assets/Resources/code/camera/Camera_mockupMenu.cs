using UnityEngine;
using System.Collections;

public class Camera_mockupMenu : MonoBehaviour {
	public string[] levels;

	void OnGUI(){
		if( levels == null ) return;

		for( int i = 0; i < levels.Length; i++ ){
			if( GUILayout.Button( levels[i] ) ){
				LoadLevel( levels[ i ] );
			}
		}

	}


	private void LoadLevel( string levelName ){
		Messenger.Broadcast<string>( "LoadState" , levelName );
	}
}
