using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void OnGUI(){
		if( GUILayout.Button( "hihihhiih" ) ){
			Messenger.Broadcast( "Spawn_SmallGuy" );
			
			//Messenger.Broadcast( "Spawn_BigGuy" );
		}
	}
}
