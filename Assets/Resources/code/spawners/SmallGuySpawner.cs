using UnityEngine;
using System.Collections;

public class SmallGuySpawner : Spawner {
	
	public bool menu = false;

	public SmallGuySpawner() : base( "SmallGuy" , "Guys" ){}

	void Start(){
		Messenger.AddListener( "SmallGuyDead" , OnSmallGuyDead );
		base.Spawn();
	}

	protected override void ConfigureSpawnedObject (GameObject spawnObject)
	{
		if( menu ){
			spawnObject.GetComponent<Input_SmallGuy>().ItIsMenu();
		}
		Messenger.Broadcast<Transform>( "SmallGuySpawned" , spawnObject.transform );
	}

	private void OnSmallGuyDead(){
		base.Spawn();
	}
}
