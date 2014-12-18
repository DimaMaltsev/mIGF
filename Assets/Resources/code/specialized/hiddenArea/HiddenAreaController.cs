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
		
		for( int i = 0 ; i < elements.Count ; i++ ){
			TriggerTypeDetectionForNeighBours( elements[i] );
		}
	}

	private void FadeElements(){
		int fadedOut = 0;
		
		for( int i = 0 ; i < elements.Count ; i++ )
			fadedOut += FadeElement( elements[ i ] ) ? 1 : 0;

		if( fadedOut == elements.Count ){
			Deactivate();
		}
	}

	private void TriggerTypeDetectionForNeighBours(Transform el){
		Vector3 p = el.position;
		Collider2D[] up 	= Physics2D.OverlapPointAll( p + Vector3.up 	);
		Collider2D[] right 	= Physics2D.OverlapPointAll( p + Vector3.right 	);
		Collider2D[] down 	= Physics2D.OverlapPointAll( p + Vector3.down 	);
		Collider2D[] left 	= Physics2D.OverlapPointAll( p + Vector3.left 	);

		Transform b_up 		= ThereIsABlock( up 	);
		Transform b_right 	= ThereIsABlock( right 	);
		Transform b_left 	= ThereIsABlock( left 	);
		Transform b_down 	= ThereIsABlock( down 	);

		Transform[] blocks = new Transform[]{ b_up, b_right, b_down, b_left };
		for( int i = 0 ; i < blocks.Length ; i++ )
			if( blocks[ i ] != null )
				blocks[ i ].GetComponent<Block_TypeDetection>().DetectMyType();
	}

	private Transform ThereIsABlock( Collider2D[] others ){
		if( others != null ){
			for( int i = 0 ; i < others.Length; i++ ){
				Collider2D block = others[ i ];
				if( block.GetComponent<Block_TypeDetection>() != null && block.transform.parent != transform )
					return block.transform;
			}
		}
		
		return null;
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
