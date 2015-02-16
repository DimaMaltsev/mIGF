using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundLibrary : MonoBehaviour {

	public AudioClip[] sounds;

	public bool muteAllSounds = false;

	private List<AudioSource> musicAudioSources = new List<AudioSource>();
	private List<AudioSource> sfxAudioSources = new List<AudioSource>();

	private float sfxVolume = 1;
	private float musicVolume = 0.3f;

	private Dictionary<string,int> soundsMap = new Dictionary<string, int> (){
		{ "boss_theme" , 0 },
		{ "chapter_1" , 1 },
		{ "chapter_unknown" , 2 },
		{ "title_theme" , 3 },
		{ "fruits" , 4 },
		{ "gwo_fall" , 5 },
		{ "gwo_jump" , 6 },
		{ "gwo_poof" , 7 },
		{ "push_start_button" , 8 },
		{ "rock" , 9 },
		{ "spikes_in" , 10 },
		{ "spikes_out" , 11 },
		{ "ti_appears" , 12 },
		{ "ti_fall" , 13 },
		{ "ti_jump" , 14 },
		{ "ti_poof" , 15 },
		{ "ti_run" , 16 },
		{ "up_and_down_menu" , 17 },
		{ "gwo_appears" , 18 }
	};

	public AudioClip GetSound( string name , AudioSource audioSource, string type ){
		if( type == "sfx" ){
			if( !sfxAudioSources.Contains( audioSource ) ){
				sfxAudioSources.Add(audioSource);
				audioSource.volume = sfxVolume;
			}
		}else if( type == "music" ){
			if( !musicAudioSources.Contains( audioSource ) ){
				musicAudioSources.Add(audioSource);
				audioSource.volume = musicVolume;
			}
		}else{
			return null;
		}

		if( soundsMap.ContainsKey( name ) )
			return sounds[ soundsMap[ name ] ];
		return null;
	}

	void Awake(){
		if( muteAllSounds ){
			sfxVolume = 0;
			musicVolume = 0;
		}
	}

	void Update(){
		for( int i = 0 ; i < sfxAudioSources.Count ; i++ ){
			if( sfxAudioSources[ i ] == null ){
				sfxAudioSources.RemoveAt( i );
				i--;
			}else{
				sfxAudioSources[ i ].volume = sfxVolume;
			}
		}

		for( int i = 0 ; i < musicAudioSources.Count ; i++ ){
			if( musicAudioSources[ i ].transform == null ){
				sfxAudioSources.RemoveAt( i );
				i--;
			}else{
				musicAudioSources[ i ].volume = musicVolume;
			}
		}
	}

	void OnGUI() {
		GUILayout.BeginHorizontal ();
		GUI.color = Color.black;

		GUILayout.BeginVertical ();
		GUILayout.Label("SFX Volume");
		GUILayout.Label("MUSIC Volume");
		GUILayout.EndVertical ();

		
		GUILayout.BeginVertical ();
		sfxVolume = GUILayout.HorizontalSlider(sfxVolume, 0, 1, GUILayout.Width(100), GUILayout.Height(20));
		musicVolume = GUILayout.HorizontalSlider(musicVolume, 0, 1, GUILayout.Width(100));
		GUILayout.EndVertical ();

		GUILayout.EndHorizontal ();
	}
}
