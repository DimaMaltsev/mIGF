using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HiddenAreaController : Interface {
	private List<Transform> elements = new List<Transform>();

	private float fadeOutSpeed = 10;

	public HiddenAreaController() : base (){
		this.executable = true;
		this.initActive = false;
	}

	void Start(){
		FillElements();
	}

	public override void Execute ()
	{
		FadeElements();
	}

	public void ActivateTrigger(){
		HideElements();
		Activate();
	}

	private void FadeElements(){
		int fadedOut = 0;
		
		for( int i = 0 ; i < elements.Count ; i++ )
			fadedOut += FadeElement( elements[ i ] ) ? 1 : 0;

		if( fadedOut == elements.Count )
			Deactivate();
	}

	private void HideElements(){
		for( int i = 0 ; i < elements.Count ; i++ )
			HideElement( elements[ i ] );
	}

	private bool FadeElement( Transform el ){
		SpriteRenderer sr = el.GetComponent<SpriteRenderer>();
		if( sr == null ) return true;
		Color c = sr.color;

		sr.color = new Color( c.r , c.g , c.b , Mathf.Lerp( c.a , 0 , fadeOutSpeed * Time.deltaTime ) );

		if( sr.color.a < 0.001f ){
			sr.color = new Color( c.r , c.g , c.b , 0 );
			return true;
		}
		return false;
	}

	private void HideElement( Transform el ){
		Collider2D[] c = el.GetComponents<Collider2D>();
		for( int i = 0 ; i < c.Length ; i++ )
			c[ i ].enabled = false;
	}

	private void FillElements(){
		for( int i = 0 ; i < transform.childCount ; i++ )
			elements.Add( transform.GetChild( i ) );
	}
}
