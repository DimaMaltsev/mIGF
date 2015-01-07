using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Block_TypeDetection : MonoBehaviour {
	private SpriteLibrary spriteLibrary;
	private SpriteRenderer spriteRenderer;
	public string tmp;

	private Dictionary<string,int> blockTypeMap = new Dictionary<string, int>{
		{ "0,1,1,1" , 0 },
		{ "1,1,0,1" , 1 },
		{ "0,1,1,0" , 2 },
		{ "0,0,1,1" , 3 },
		{ "1,0,0,1" , 4 },
		{ "1,1,0,0" , 5 },
		{ "0,1,0,0" , 6 },
		{ "0,0,0,1" , 7 },
		{ "0,0,1,0" , 8 },
		{ "1,0,0,0" , 9 },
		{ "0,0,0,0" , 10 },
		{ "0,1,0,1" , 11 },
		{ "1,0,1,0" , 12 },
		{ "1,1,1,0" , 13 },
		{ "1,0,1,1" , 14 },
		{ "1,1,1,1" , 15 }
	};

	private Dictionary<string,Dictionary<string,int>> blockCornersTypeMap = new Dictionary<string, Dictionary<string,int>>{
		// _|
		{ 
			"1,1,0,0", new Dictionary<string, int >{
				{"0,0,0,0", 36}
			}
		},
		{ 
			"0,1,1,0", new Dictionary<string, int >{
				{"0,0,0,0", 33}
			}
		},
		{ 
			"0,0,1,1", new Dictionary<string, int >{
				{"0,0,0,0", 34}
			}
		},
		{
			"1,0,0,1", new Dictionary<string, int >{
				{"0,0,0,0", 35}
			}
		},
		// _|_
		{
			"1,1,0,1", new Dictionary<string, int >{
				{"0,0,0,0", 27}
			}
		},
		{
			"0,1,1,1", new Dictionary<string, int >{
				{"0,0,0,0", 25}
			}
		},
		{
			"1,0,1,1", new Dictionary<string, int >{
				{"0,0,0,0", 26}
			}
		},
		{
			"1,1,1,0", new Dictionary<string, int >{
				{"0,0,0,0", 24}
			}
		},
		// .
		{
			"1,1,1,1", new Dictionary<string, int >{
				{"0,0,0,0", 32},
				{"0,0,1,0", 31},
				{"1,0,0,0", 28},
				{"0,1,0,0", 29},
				{"0,0,0,1", 30},
				{"1,1,0,0", 21},
				{"0,1,0,1", 22},
				{"0,0,1,1", 23},
				{"1,0,1,0", 20},
				{"0,1,1,1", 16},
				{"1,1,0,1", 17},
				{"1,1,1,0", 18},
				{"1,0,1,1", 19}
			}
		}

	};

	void Awake(){
		spriteLibrary = GameObject.FindGameObjectWithTag( "SpriteLibrary" ).GetComponent<SpriteLibrary>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Start(){
		DetectMyType();
	}

	public void DetectMyType(){
		Vector3 p = transform.position;

		Collider2D[] up 	= Physics2D.OverlapPointAll( p + Vector3.up 	);
		Collider2D[] right 	= Physics2D.OverlapPointAll( p + Vector3.right 	);
		Collider2D[] down 	= Physics2D.OverlapPointAll( p + Vector3.down 	);
		Collider2D[] left 	= Physics2D.OverlapPointAll( p + Vector3.left 	);

		Collider2D[] upLeft 	= Physics2D.OverlapPointAll( p + Vector3.up 	+ Vector3.left	);
		Collider2D[] upRight 	= Physics2D.OverlapPointAll( p + Vector3.up 	+ Vector3.right );
		Collider2D[] downLeft 	= Physics2D.OverlapPointAll( p + Vector3.down 	+ Vector3.left 	);
		Collider2D[] downRight 	= Physics2D.OverlapPointAll( p + Vector3.down	+ Vector3.right );

		bool b_up 		= ThereIsABlock( up 	);
		bool b_right 	= ThereIsABlock( right 	);
		bool b_left 	= ThereIsABlock( left 	);
		bool b_down 	= ThereIsABlock( down 	);

		bool b_up_left 		= ThereIsABlock( upLeft 	);
		bool b_up_right 	= ThereIsABlock( upRight 	);
		bool b_down_left 	= ThereIsABlock( downLeft 	);
		bool b_down_right 	= ThereIsABlock( downRight 	);

		string type = 
			( b_up 		? "1" : "0" ) + "," + 
			( b_right 	? "1" : "0" ) + "," + 
			( b_down 	? "1" : "0" ) + "," + 
			( b_left 	? "1" : "0" );
		string cornerType =
			( b_up_left 	? "1" : "0" ) + "," + 
			( b_up_right 	? "1" : "0" ) + "," + 
			( b_down_left 	? "1" : "0" ) + "," + 
			( b_down_right 	? "1" : "0" );
		
		tmp = type + "   " + cornerType;
		int outputType = blockTypeMap[ type ];
		if(blockCornersTypeMap.ContainsKey(type)){
			Dictionary<string,int> ct = blockCornersTypeMap[type];
			if(ct.ContainsKey(cornerType))
				outputType = ct[cornerType];
		}
		spriteRenderer.sprite = spriteLibrary.blocks[ outputType ];
	}

	private bool ThereIsABlock( Collider2D[] others ){
		if( others != null ){
			for( int i = 0 ; i < others.Length; i++ ){
				Collider2D block = others[ i ];
				if( ThisBlockIsValid( block ) )
					return true;
			}
		}

		return false;
	}

	private bool ThisBlockIsValid( Collider2D block ){
		return 
			block.GetComponent<Block_TypeDetection>() != null && 
				( block.transform.parent == transform.parent || 
				 block.transform.parent.tag == "Hidden_Area" || transform.parent.tag == "Hidden_Area");
	}
}
