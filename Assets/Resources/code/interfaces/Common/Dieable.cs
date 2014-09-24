using UnityEngine;
using System.Collections;

public class Dieable : Interface {

	public Dieable() : base() {}

	public void DestroyMyself(){
		Destroy( gameObject );
	}
	public void Die(){
		SendMessage( "TheyWantMeToDie" , SendMessageOptions.DontRequireReceiver );
	}
}
