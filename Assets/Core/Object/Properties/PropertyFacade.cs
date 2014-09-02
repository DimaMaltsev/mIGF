using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PropertyFacade {
	private Dictionary<string,Property> properties = new Dictionary<string, Property>();

	private Property FindProperty( string name ){
		if (properties.ContainsKey (name)) {
			return properties[ name ];
		}else{
			return null;
		}
	}

	private Property FindPropertyFor( string name , string getOrSet = "GET" ){
		Property p = FindProperty( name );
		if( p == null ){
			Debug.Log( getOrSet + " not existing property '" + name + "'" );
			return null;
		}
		return p;
	}


	public void AddProperty( string name , bool allowRepeatings = false ){

		string type = PropertyRegistry.GetType( name );
		if( type == "" ){
			Debug.Log( "Trying to add not declared property '" + name + "'. tip ~~~~ declare it in PropertyRegistry" );
			return;
		}

		if ( !allowRepeatings && properties.ContainsKey (name)) {
			Debug.Log( "Trying to add already existing property '" + name + "'" );
			return;
		}
		if( !properties.ContainsKey( name ) )
			properties.Add (name, new Property (type) );
	}

	public float GetPropertyNumber( string name ){
		Property p = FindPropertyFor( name );
		return float.Parse( p.Get() );
	}

	public string GetPropertyString( string name ){
		Property p = FindPropertyFor( name );
		return p.Get();
	}

	public bool GetPropertyBoolean( string name ){
		Property p = FindPropertyFor( name );
		return bool.Parse( p.Get() );
	}

	public void SetProperty( string name , object value ){
		Property p = FindPropertyFor( name , "SET" );
		p.Set( value );
	}
}
