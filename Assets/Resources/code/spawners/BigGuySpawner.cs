using UnityEngine;
using System.Collections;

public class BigGuySpawner : Spawner {

	public bool menu = false;

	public BigGuySpawner() : base( "BigGuy" , "Guys" ){}

	void Start(){
		Messenger.AddListener( "BigGuyDead" , OnBigGuyDead );
		base.Spawn();
	}

	protected override void ConfigureSpawnedObject (GameObject spawnObject)
	{
		if( menu ){
			spawnObject.GetComponent<Input_BigGuy>().ItIsMenu();
		}
		Messenger.Broadcast<Transform>( "BigGuySpawned" , spawnObject.transform );
	}

	private void OnBigGuyDead(){
		base.Spawn();
	}
}
