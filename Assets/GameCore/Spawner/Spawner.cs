using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	private string spawnObjectName;
	private string path;

	private Transform LevelContainer;
	private AudioSource audioSource;

	protected string spawnSoundName = "";

	public Spawner( string objectName , string pathToObject ){
		this.spawnObjectName = objectName;
		this.path = pathToObject;
	}

	void Awake(){
		Messenger.AddListener( "Spawn_" + spawnObjectName , Spawn );
		GetComponent<SpriteRenderer>().enabled = false;
		audioSource = GetComponent<AudioSource> ();

		GameObject soundLibGameObj = GameObject.FindGameObjectWithTag( "SoundLibrary" );
		if( soundLibGameObj != null ){
			SoundLibrary soundLibrary = soundLibGameObj.GetComponent<SoundLibrary>();

			if (spawnSoundName != "" ){
				AudioClip sound = soundLibrary.GetSound( spawnSoundName , audioSource , "sfx" );
				audioSource.clip = sound;
			}
		}

		LevelContainer = GameObject.FindGameObjectWithTag( "LevelContainer" ).transform;
	}

	protected virtual void ConfigureSpawnedObject( GameObject spawnObject ){}

	protected void Spawn(){
		GameObject obj = (GameObject)Instantiate( Resources.Load( "Objects/" + path + "/" + spawnObjectName ) );
		obj.transform.parent = LevelContainer;
		obj.transform.localPosition = Vector3.zero;
		obj.transform.position = transform.position;

		ConfigureSpawnedObject( obj );

		if( audioSource.clip != null ){
			audioSource.Play();
		}
	}
}
