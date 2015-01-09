using UnityEngine;
using System.Collections;

public class SpikeController : MonoBehaviour {

	public bool openedOnStart;

	public bool opened = false;

	private SpriteRenderer sr;
	private BoxCollider2D cldr;
	private Animator a;

	void Awake(){
		sr = GetComponent<SpriteRenderer>();
		cldr = GetComponent<BoxCollider2D>();
		a = GetComponent<Animator> ();
	}

	void Start(){
		opened = !openedOnStart;
		SwitchActive();
	}

	public void SwitchActive(){
		opened = !opened;
		if( opened )
			Open();
		else
			Close();
	}

	private void Open(){
		cldr.enabled = true;
		a.SetBool ("opened", true);
	}

	private void Close(){
		cldr.enabled = false;
		a.SetBool ("opened", false);
	}

	private void ActivateTrigger(){
		SwitchActive();
	}
}
