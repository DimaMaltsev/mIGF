using UnityEngine;
using System.Collections;

public class ObjectController : MonoBehaviour {
	private PropertyFacade 	propertyFacade 	= new PropertyFacade();
	private InterfaceFacade	interfaceFacade	= new InterfaceFacade();

	void Awake(){
		interfaceFacade.Init( gameObject );
	}

	void Start(){
		interfaceFacade.ActivateStartInterfaces();
	}


	void Update(){
		interfaceFacade.ExecuteInterfaces();
	}
	/*void Start(){
		propertyFacade.AddProperty( "x" );
		propertyFacade.AddProperty( "alive" );

		//propertyFacade.SetProperty( "alive" , 2 );
		Debug.Log( propertyFacade.GetPropertyBoolean( "alive" ) );
	}*/

	public void AddVariables( string[] variables ){
		for( int i = 0 ; i < variables.Length ; i++ ){
			propertyFacade.AddProperty( variables[ i ] , true );
		}
	}

	public PropertyFacade Props(){
		return propertyFacade;
	}
}
