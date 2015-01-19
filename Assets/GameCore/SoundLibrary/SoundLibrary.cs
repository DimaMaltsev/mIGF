using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundLibrary : MonoBehaviour {

	public AudioClip[] sounds;

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

	public AudioClip GetSound( string name ){
		if( soundsMap.ContainsKey( name ) )
			return sounds[ soundsMap[ name ] ];
		return null;
	}
}
