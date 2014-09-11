using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Block_TypeDetection : MonoBehaviour {
	private SpriteLibrary spriteLibrary;
	private SpriteRenderer spriteRenderer;

	private Dictionary<string,int> blockTypeMap = new Dictionary<string, int>{
		{ "0,0,0,0" , 10 },
		{ "1,0,0,0" , 9 },
		{ "0,1,0,0" , 6 },
		{ "0,0,1,0" , 8 },
		{ "0,0,0,1" , 7 },
		{ "1,1,0,0" , 5 },
		{ "1,0,1,0" , 12 },
		{ "1,0,0,1" , 4 },
		{ "0,1,1,0" , 2 },
		{ "0,1,0,1" , 11 },
		{ "0,0,1,1" , 3 },
		{ "1,1,1,0" , 13 },
		{ "1,1,0,1" , 1 },
		{ "1,0,1,1" , 14 },
		{ "0,1,1,1" , 0 },
		{ "1,1,1,1" , 15 }
	};

	void Awake(){
		spriteLibrary = GameObject.FindGameObjectWithTag( "SpriteLibrary" ).GetComponent<SpriteLibrary>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Start(){
		DetectMyType();
	}

	private void DetectMyType(){
		Vector3 p = transform.position;

		Collider2D[] up 	= Physics2D.OverlapPointAll( p + Vector3.up 	);
		Collider2D[] right 	= Physics2D.OverlapPointAll( p + Vector3.right 	);
		Collider2D[] down 	= Physics2D.OverlapPointAll( p + Vector3.down 	);
		Collider2D[] left 	= Physics2D.OverlapPointAll( p + Vector3.left 	);

		bool b_up 		= ThereIsABlock( up 	);
		bool b_right 	= ThereIsABlock( right 	);
		bool b_left 	= ThereIsABlock( left 	);
		bool b_down 	= ThereIsABlock( down 	);

		string type = 
			( b_up ? "1" : "0" ) + "," + 
			( b_right ? "1" : "0" ) + "," + 
			( b_down ? "1" : "0" ) + "," + 
			( b_left ? "1" : "0" );

		spriteRenderer.sprite = spriteLibrary.blocks[ blockTypeMap[ type ] ];
	}

	private bool ThereIsABlock( Collider2D[] others ){
		if( others != null ){
			for( int i = 0 ; i < others.Length; i++ ){
				if( others[ i ].GetComponent<Block_TypeDetection>() != null )
					return true;
			}
		}

		return false;
	}
}
