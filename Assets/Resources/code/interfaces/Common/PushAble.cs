using UnityEngine;
using System.Collections;

public class PushAble : MonoBehaviour {
	public bool canBePushed = true;
	public void Push( object param = null ){
		SendMessage( "IveBeingPushed" , param , SendMessageOptions.DontRequireReceiver );
	}
}
