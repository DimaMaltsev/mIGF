﻿using UnityEngine;
using System.Collections;

public class Dieable : Interface {

	public Dieable() : base() {}

	public void DestroyMyself(){
		Destroy( gameObject );
	}
	public void Die( string reason = "none" ){
		SendMessage( "TheyWantMeToDie" , reason , SendMessageOptions.DontRequireReceiver );
	}
}
