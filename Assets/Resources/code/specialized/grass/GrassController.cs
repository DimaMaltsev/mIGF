using UnityEngine;
using System.Collections;

public class GrassController : MonoBehaviour {

	private Animator a;

	void Awake(){
		a = GetComponent<Animator> ();
	}


	void OnTriggerStay2D(Collider2D other){
		ObjectController objController = other.GetComponent<ObjectController> ();
		float sx;

		if(objController == null) return;

		sx = objController.propertyFacade.GetPropertyNumber ("sx");
		if(sx == null) return;

		if( sx > 0 )
			PlayRight();
		else if( sx < 0 )
			PlayLeft();
		else
			return;

		if( IsInvokingResetAnimator() )
			CancelInvokeResetAnimator();

		InvokeResetAnimator ();
	}

	private void PlayRight(){
		a.SetBool ("right", true);
	}

	
	private void PlayLeft(){
		a.SetBool ("left", true);
	}

	private void ResetAnimator(){
		a.SetBool ("right", false);
		a.SetBool ("left", false);
	}

	private bool IsInvokingResetAnimator(){
		return IsInvoking ("ResetAnimator");
	}

	private void CancelInvokeResetAnimator(){
		CancelInvoke ("ResetAnimator");
	}

	private void InvokeResetAnimator(){
		Invoke("ResetAnimator", 0.01f);
	}
}
