using UnityEngine;
using System.Collections;

public class BigGuySpawner : Spawner {

	public BigGuySpawner() : base( "BigGuy" , "Guys" ){}

	protected override void ConfigureSpawnedObject (GameObject spawnObject)
	{
		Messenger.Broadcast<Transform>( "BigGuySpawned" , spawnObject.transform );
	}
}
