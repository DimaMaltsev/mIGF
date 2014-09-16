using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {
	protected bool executable = false;
	protected bool initActive = false;
	protected bool executing  = false;

	protected string[] variables;

	protected ObjectController 	controller;
	protected PropertyFacade	properties;
	protected InterfaceFacade	interfaces;

	public Interface( params string[] variables ){
		this.variables = variables;
	}

	void Awake(){
		controller = gameObject.GetComponent<ObjectController>();
		properties = controller.Props();
		interfaces = controller.Inters();

		controller.AddVariables( variables );
		SetStartingValues();
	}

	public virtual void Execute(){
		if( CodeConfig.DEBUG_MODE )
			Debug.LogWarning( "Executing the interface with not declared body" );
	}

	protected virtual void SetStartingValues(){}

	public bool Executable(){	return executable;	}
	public bool InitActive(){	return initActive;	}
	public bool Executing(){	return executing;	}

	public void Activate(){ 	executing = true; interfaces.ActivateInterface( this );	}
	public void Deactivate(){ 	executing = false;interfaces.DeactivateInterface( this ); 	}

}
