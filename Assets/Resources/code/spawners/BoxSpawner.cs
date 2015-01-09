using UnityEngine;
using System.Collections;

public class BoxSpawner : Spawner {

	public BoxSpawner() : base( "Box" , "Environment" ){}
	public bool spawnOnStart = true;
	public bool autoRespawn = true;
	public int boxesCountLimit = 1;

	private int boxesCount = 0;

	void Start(){
		Messenger.AddListener( "BoxDead" , OnBoxDead );
		boxesCount--;

		if(spawnOnStart){
			InternalSpawn();
		}
	}
	
	private void OnBoxDead(){
		if( autoRespawn ){
			InternalSpawn();
		}
	}
	private void ActivateTrigger(){
		InternalSpawn();
	}

	private void InternalSpawn(){
		if( boxesCount >= boxesCountLimit ) return;

		boxesCount ++;
		base.Spawn ();
	}
}
