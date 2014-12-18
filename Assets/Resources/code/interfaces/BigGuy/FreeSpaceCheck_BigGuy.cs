using UnityEngine;
using System.Collections;

public class FreeSpaceCheck_BigGuy : Interface {

	public FreeSpaceCheck_BigGuy() : base(){
		this.executable = true;
		this.initActive = true;
	}

	public override void Execute ()
	{
		TriggerTypeDetectionForNeighBours ();
	}

	private void TriggerTypeDetectionForNeighBours(){
		Vector3 p = transform.position;
		Collider2D[] up1 	= Physics2D.OverlapPointAll( p + Vector3.up - Vector3.right * 0.5f	);
		Collider2D[] up2 	= Physics2D.OverlapPointAll( p + Vector3.up + Vector3.right * 0.5f	);

		Collider2D[] down1 	= Physics2D.OverlapPointAll( p + Vector3.down - Vector3.right * 0.5f	);
		Collider2D[] down2 	= Physics2D.OverlapPointAll( p + Vector3.down + Vector3.right * 0.5f	);

		Collider2D[] right1 	= Physics2D.OverlapPointAll( p + Vector3.right + Vector3.up * 0.5f	);
		Collider2D[] right2 	= Physics2D.OverlapPointAll( p + Vector3.right - Vector3.up * 0.5f	);

		Collider2D[] left1 	= Physics2D.OverlapPointAll( p + Vector3.left + Vector3.up * 0.5f	);
		Collider2D[] left2 	= Physics2D.OverlapPointAll( p + Vector3.left - Vector3.up * 0.5f	);
		
		bool b_up 		= ThereIsSomething( up1 	) || ThereIsSomething( up2	);
		bool b_right 	= ThereIsSomething( right1 	) || ThereIsSomething( right2 );
		bool b_left 	= ThereIsSomething( left1 	) || ThereIsSomething( left2 );
		bool b_down 	= ThereIsSomething( down1 	) || ThereIsSomething( down2 );

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
				   block.GetComponent<DoorController>() != null
				   )
					return true;
			}
		}
		
		return false;
	}
}
