using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private int waitingForObjectsCount = 0;
	private int objectsReachedEndCount = 0;

	void Start(){
		Messenger.AddListener( "GuyReachedEndPoint" , OnGuyReachedEndPoint	);
		Messenger.AddListener( "GuyLeavedEndPoint" 	, OnGuyLeavedEndPoint 	);

		if( GameObject.FindGameObjectWithTag( "SmallGuySpawner" ) 	!= null ) waitingForObjectsCount++;
		if( GameObject.FindGameObjectWithTag( "BigGuySpawner" ) 	!= null ) waitingForObjectsCount++;

	}

	private void OnGuyReachedEndPoint(){ objectsReachedEndCount++; FinishGame(); }
	private void OnGuyLeavedEndPoint(){ objectsReachedEndCount--; }

	private void StartGame(){}

	private void FinishGame(){
		if( objectsReachedEndCount != waitingForObjectsCount ) return;
		Messenger.Broadcast<string>( "LoadState" , "main" );
	}
}
