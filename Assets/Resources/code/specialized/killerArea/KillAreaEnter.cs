using UnityEngine;
using System.Collections;

public class KillAreaEnter : MonoBehaviour {
	public string[] canAffect;
	public bool killAll;

	private void OnTriggerEnter2D( Collider2D other ){
		if( canAffect == null ) return;

		if( !killAll && other.tag != "" ){
			for( int i = 0 ; i < canAffect.Length ; i++ ){
				if( canAffect[ i ] == other.tag ){
					Dieable die = other.GetComponent<Dieable>();
					if( die == null ){
						Debug.LogError( "Killing zone is trying to kill object that doesnt have Dieable interface" );
						return;
					}
					die.Die( "KillArea" );
					return;
				}
			}
		}else if( killAll ){
			Dieable die = other.GetComponent<Dieable>();
			if( die != null )
				die.Die( "KillArea" );
		}
	}
}
