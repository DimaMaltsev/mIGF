using UnityEngine;
using System.Collections;

public class SmallGuySpawner : Spawner {

	public SmallGuySpawner() : base( "SmallGuy" , "Guys" ){}

	protected override void ConfigureSpawnedObject (GameObject spawnObject)
	{
		Messenger.Broadcast<Transform>( "SmallGuySpawned" , spawnObject.transform );
	}
}
