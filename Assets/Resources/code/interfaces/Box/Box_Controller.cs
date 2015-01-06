using UnityEngine;
using System.Collections;

public class Box_Controller : Interface {
	public float sleepingTimer = 2;	
	private bool sleeping = false;
	public Box_Controller() : base ( "sx" , "sy" ){
		this.initActive = true;
	}
	
	protected override void SetStartingValues ()
	{
		FallAsleep ();
	}

	private void ResetAndLaunchSleepingTimer(){
		if(IsInvoking("FallAsleep")){
			CancelInvoke("FallAsleep");
		}

		Invoke ("FallAsleep", sleepingTimer);
	}

	private void FallAsleep(){
		if(!sleeping){
			sleeping = true;
		}
		SleepingAnimationUpdate ();
	}

	public void WakeUp(){
		if( sleeping ){
			sleeping = false;
		}
		SleepingAnimationUpdate ();
	}

	private void SleepingAnimationUpdate(){
		GetComponent<Animator> ().SetBool ("sleeping", sleeping);
	}

	public void Touched(){
		WakeUp ();
		ResetAndLaunchSleepingTimer ();
	}

	public void Land(){
		GetComponent<Animator> ().SetBool ("landing", true);
		if( IsInvoking("DisLand") ){
			CancelInvoke("DisLand");
		}
		Invoke ("DisLand", 0.1f);
	}
	private void DisLand(){
		GetComponent<Animator> ().SetBool ("landing", false);
	}
}
