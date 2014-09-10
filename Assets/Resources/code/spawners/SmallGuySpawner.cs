using UnityEngine;
using System.Collections;

public class SmallGuySpawner : Spawner {

	public SmallGuySpawner() : base( "SmallGuy" , "Guys" ){}

	void Start(){
		Messenger.AddListener( "SmallGuyDead" , OnSmallGuyDead );
		base.Spawn();
	}

	protected override void ConfigureSpawnedObject (GameObject spawnObject)
	{
		Messenger.Broadcast<Transform>( "SmallGuySpawned" , spawnObject.transform );
	}

	private void OnSmallGuyDead(){
		base.Spawn();
	}
}
