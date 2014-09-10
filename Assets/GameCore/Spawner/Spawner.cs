using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	private string spawnObjectName;
	private string path;

	private Transform LevelContainer;

	public Spawner( string objectName , string pathToObject ){
		this.spawnObjectName = objectName;
		this.path = pathToObject;
	}

	void Awake(){
		Messenger.AddListener( "Spawn_" + spawnObjectName , Spawn );
		GetComponent<SpriteRenderer>().enabled = false;

		LevelContainer = GameObject.FindGameObjectWithTag( "LevelContainer" ).transform;
	}

	protected virtual void ConfigureSpawnedObject( GameObject spawnObject ){}

	protected void Spawn(){
		GameObject obj = (GameObject)Instantiate( Resources.Load( "Objects/" + path + "/" + spawnObjectName ) );
		obj.transform.parent = LevelContainer;
		obj.transform.localPosition = Vector3.zero;
		obj.transform.position = transform.position;

		ConfigureSpawnedObject( obj );
	}
}
