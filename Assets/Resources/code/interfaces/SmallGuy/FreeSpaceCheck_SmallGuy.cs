using UnityEngine;
using System.Collections;

public class FreeSpaceCheck_SmallGuy : Interface {

	public FreeSpaceCheck_SmallGuy() : base(){
		this.executable = true;
		this.initActive = true;
	}

	public override void Execute ()
	{
		TriggerTypeDetectionForNeighBours ();
	}

	private void TriggerTypeDetectionForNeighBours(){
		Vector3 p = transform.position;
		Collider2D[] up 	= Physics2D.OverlapPointAll( p + Vector3.up * 0.5f 	);
		Collider2D[] right 	= Physics2D.OverlapPointAll( p + Vector3.right * 0.5f 	);
		Collider2D[] down 	= Physics2D.OverlapPointAll( p + Vector3.down * 0.5f 	);
		Collider2D[] left 	= Physics2D.OverlapPointAll( p + Vector3.left * 0.5f 	);
		
		bool b_up 		= ThereIsSomething( up 	);
		bool b_right 	= ThereIsSomething( right 	);
		bool b_left 	= ThereIsSomething( left 	);
		bool b_down 	= ThereIsSomething( down 	);

		if( b_up && b_down || b_left && b_right ){
			GetComponent<Dieable>().Die();
		}
	}

	private bool ThereIsSomething( Collider2D[] others ){
		if( others != null ){
			for( int i = 0 ; i < others.Length; i++ ){
				Collider2D block = others[ i ];
				if( 
				   block.GetComponent<Block_TypeDetection>() != null || 
				   block.GetComponent<Box_Moves>() != null ||
				   block.GetComponent<DoorController>() != null ||
				   block.GetComponent<CrumblingWallController>() != null
				   )
					return true;
			}
		}
		
		return false;
	}
}
