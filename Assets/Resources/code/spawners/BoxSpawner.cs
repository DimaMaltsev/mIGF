using UnityEngine;
using System.Collections;

public class BoxSpawner : Spawner {

	public BoxSpawner() : base( "Box" , "Environment" ){}

	void Start(){
		Messenger.AddListener( "BoxDead" , OnBoxDead );
		base.Spawn();
	}
	
	private void OnBoxDead(){
		base.Spawn();
	}
}
