using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class PropertyRegistry {

	private static Dictionary<string,string> propertyRegestry = new Dictionary<string, string>{
		{ "x" , "number" },
		{ "y" , "number" },

		{ "alive" , "boolean" }
	};
	
	public static string GetType( string propName ){
		if( !propertyRegestry.ContainsKey( propName ) ){
			Debug.Log( "You'r trying to get type of not declared property '" + propName + "'" );
			return "";
		}
		
		return propertyRegestry[ propName ];
	}
	
}
