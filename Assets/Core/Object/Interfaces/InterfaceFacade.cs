using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InterfaceFacade {
	private Interface[] interfaces;
	private List<Interface> activeInterfaces = new List<Interface>();

	public InterfaceFacade(){}

	public void Init( GameObject myObject ){
		interfaces = myObject.GetComponents<Interface>();
	}

	public void ActivateStartInterfaces(){

		for( int j = 0 ; j < interfaces.Length ; j++ ){
			Interface i = interfaces[ j ];

			if( i.InitActive() && i.Executable() )
				ActivateInterface( i );
		}
	}

	public void ExecuteInterfaces(){
		for( int i = 0 ; i < activeInterfaces.Count ; i++ )
			activeInterfaces[ i ].Execute();
	}

	private void ActivateInterface( Interface i ){
		if( CodeConfig.DEBUG_MODE && activeInterfaces.Contains( i ) ){
			Debug.LogWarning( "Trying to activate interface twice '" + i.name + "'" );
			return;
		}

		i.Activate();
		activeInterfaces.Add( i );
	}
}
