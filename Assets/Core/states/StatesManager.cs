using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatesManager : MonoBehaviour {

	public string initState = "main";


	public string levelStateChangePurpose = "";
	public string currentState = "";
	private string nextState = "";

	private void CleanUpLastLevel(){
		Messenger.Cleanup();
		GameObject container = GameObject.FindGameObjectWithTag( "LevelContainer" );
		if( container != null )
			container.GetComponent<Remover>().Remove();
	}
	
	private void LoadState( string state ){
		CleanUpLastLevel();
		Application.LoadLevelAdditive( state );
		SubscribeOnEvents();
	}
	
	private void SubscribeOnEvents(){
		Messenger.AddListener( "CoreLoaded" , OnCoreLoaded );
		Messenger.AddListener<string[]>( "LoadState" , OnLoadState );
	}
	private void UnSubscribeOnEvents(){}
	
	// ---------- EVENT HANDLERS -------------
	
	private void OnCoreLoaded(){
		LoadState( initState );
	}
	
	private void OnLoadState( string[] state ){
		levelStateChangePurpose = "";

		if (state.Length == 0) {
			LoadState("main");
			return;
		}

		if (state.Length == 1 && state[0] == "map" ) {
			LoadState("map");
			return;
		}

		if (state.Length == 1 && state[0] == "restart" ) {
			LoadState(currentState);
			levelStateChangePurpose = "restart";
			return;
		}

		currentState = state[0];
		nextState = state[1];
		LoadState( currentState );
	}
	
	// -------------- ROUTINE ----------------
	
	void OnEnable(){
		SubscribeOnEvents();
	}
	
	void OnDisable(){
		UnSubscribeOnEvents();
	}
	
	void Start(){
		OnCoreLoaded();
	}
}
