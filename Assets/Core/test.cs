using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void OnGUI(){
		if( GUILayout.Button( "hihi" ) )
			GetComponent<Activator>().Activate();
	}
}
