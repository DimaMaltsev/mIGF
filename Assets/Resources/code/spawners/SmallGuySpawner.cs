using UnityEngine;
using System.Collections;

public class SmallGuySpawner : Spawner {
	
	public bool menu = false;

	public SmallGuySpawner() : base( "SmallGuy" , "Guys" ){
		this.spawnSoundName = "ti_appears";
	}

	void Start(){
		Invoke ("RealSpawn", 0.5f);
	}

	protected override void ConfigureSpawnedObject (GameObject spawnObject){
		if( menu ){
			spawnObject.GetComponent<Input_SmallGuy>().ItIsMenu();
		}
		Messenger.Broadcast<Transform>( "SmallGuySpawned" , spawnObject.transform );
	}

	private void RealSpawn(){
		base.Spawn ();
	}
}
