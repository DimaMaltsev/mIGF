using UnityEngine;
using System.Collections;

public class SpikeController : MonoBehaviour {

	public bool openedOnStart;

	public bool opened = false;

	private SpriteRenderer sr;
	private BoxCollider2D cldr;
	private Animator a;

	private AudioSource audioSource;
	private SoundLibrary soundLibrary;

	void Awake(){
		sr = GetComponent<SpriteRenderer>();
		cldr = GetComponent<BoxCollider2D>();
		a = GetComponent<Animator> ();

		audioSource = GetComponent<AudioSource> ();
		GameObject soundLibGameObj = GameObject.FindGameObjectWithTag( "SoundLibrary" );
		if( soundLibGameObj != null ){
			soundLibrary = soundLibGameObj.GetComponent<SoundLibrary>();
		}
	}

	void Start(){
		opened = !openedOnStart;
		SwitchActive();
	}

	public void SwitchActive(){
		opened = !opened;
		if( opened )
			Open();
		else
			Close();
	}

	private void Open(){
		cldr.enabled = true;
		a.SetBool ("opened", true);
		PlaySound ("spikes_out");
	}

	private void Close(){
		cldr.enabled = false;
		a.SetBool ("opened", false);
		PlaySound ("spikes_in");
	}

	private void ActivateTrigger(){
		SwitchActive();
	}

	private void PlaySound(string soundName){
		AudioClip sound = soundLibrary.GetSound( soundName , audioSource , "sfx" );
		audioSource.clip = sound;
		audioSource.Play ();
	}
}
