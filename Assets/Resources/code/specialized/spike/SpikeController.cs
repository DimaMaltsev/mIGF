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
		SwitchActive(true);
	}

	public void SwitchActive(bool init = false){
		opened = !opened;
		if( opened )
			Open(init);
		else
			Close(init);
	}

	private void Open(bool init){
		cldr.enabled = true;
		a.SetBool ("opened", true);
		if( !init )
			PlaySound ("spikes_out");
	}

	private void Close(bool init){
		cldr.enabled = false;
		a.SetBool ("opened", false);
		if (!init)
			PlaySound ("spikes_in");
	}

	private void ActivateTrigger(){
		SwitchActive();
	}

	private void PlaySound(string soundName){
		if( soundLibrary == null ) return;
		AudioClip sound = soundLibrary.GetSound( soundName , audioSource , "sfx" );
		audioSource.clip = sound;
		audioSource.Play ();
	}
}
