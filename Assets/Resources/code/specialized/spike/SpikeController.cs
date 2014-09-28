using UnityEngine;
using System.Collections;

public class SpikeController : MonoBehaviour {
	public Sprite OpenedSpikeSprite;
	public Sprite ClosedSpikeSprite;

	public bool openedOnStart;

	private bool opened = false;
	private SpriteRenderer sr;
	private BoxCollider2D cldr;

	void Awake(){
		sr = GetComponent<SpriteRenderer>();
		cldr = GetComponent<BoxCollider2D>();
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
		sr.sprite = OpenedSpikeSprite;
		cldr.enabled = true;
	}

	private void Close(){
		sr.sprite = ClosedSpikeSprite;
		cldr.enabled = false;
	}

	private void ActivateTrigger(){
		SwitchActive();
	}
}
