using UnityEngine;
using System.Collections;

public class Property {
	private object value;
	private string type;

	public Property( string type = "string" ){
		switch( type ){
		case "number" 	: this.value = 0; 		break;
		case "boolean"	: this.value = false; 	break;
		case "string"	: this.value = "";		break;
		}
		this.type = type;
	}
	public void Set(object value){ 
		if( CodeConfig.DEBUG_MODE ){
			switch( this.type ){
			case "number" 	: float.Parse( value.ToString() ); break;
			case "boolean"	: bool.Parse( value.ToString() ); break;
			}
		}

		this.value = value; 
	}
	public virtual string Get(){ return value.ToString (); }
}