using UnityEngine;
using System.Collections;

public class BigGuySpawner : Spawner {

	public BigGuySpawner() : base( "BigGuy" , "Guys" ){}

	void Start(){
		Messenger.AddListener( "BigGuyDead" , OnBigGuyDead );
		base.Spawn();
	}

	protected override void ConfigureSpawnedObject (GameObject spawnObject)
	{
		Messenger.Broadcast<Transform>( "BigGuySpawned" , spawnObject.transform );
	}

	private void OnBigGuyDead(){
		base.Spawn();
	}
}
