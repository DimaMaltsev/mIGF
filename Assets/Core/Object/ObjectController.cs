using UnityEngine;
using System.Collections;

public class ObjectController : MonoBehaviour {
	public PropertyFacade 	propertyFacade 	= new PropertyFacade();
	public InterfaceFacade	interfaceFacade	= new InterfaceFacade();

	private AudioSource[] audioSources;
	private SoundLibrary soundLibrary;

	void Awake(){
		interfaceFacade.Init( gameObject );
		audioSources = GetComponents<AudioSource> ();
		if( GameObject.FindGameObjectWithTag ("SoundLibrary") )
			soundLibrary = GameObject.FindGameObjectWithTag ("SoundLibrary").GetComponent<SoundLibrary> ();
	}

	void Start(){
		interfaceFacade.ActivateStartInterfaces();
	}


	void Update(){
		interfaceFacade.ExecuteInterfaces();
	}

	public void AddVariables( string[] variables ){
		for( int i = 0 ; i < variables.Length ; i++ ){
			propertyFacade.AddProperty( variables[ i ] , true );
		}
	}

	public PropertyFacade Props(){
		return propertyFacade;
	}

	public InterfaceFacade Inters(){
		return interfaceFacade;
	}

	public void PlaySound(string name, int audioSourceIndex = 0){
		if( soundLibrary == null ) return;
		AudioClip clip = soundLibrary.GetSound (name, audioSources[audioSourceIndex], "sfx");
		audioSources[ audioSourceIndex ].clip = clip;
		audioSources[ audioSourceIndex ].Play();
	}
}
