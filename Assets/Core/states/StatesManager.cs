using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatesManager : MonoBehaviour {

	public string initState = "main";
	
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
		Messenger.AddListener<string>( "LoadState" , OnLoadState );
	}
	private void UnSubscribeOnEvents(){}
	
	// ---------- EVENT HANDLERS -------------
	
	private void OnCoreLoaded(){
		LoadState( initState );
	}
	
	private void OnLoadState( string state ){
		LoadState( state );
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
