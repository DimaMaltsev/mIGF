using UnityEngine;
using System.Collections;

public class FreeSpaceCheck_SmallGuy : Interface {
	bool dead = false;
	public FreeSpaceCheck_SmallGuy() : base(){
		this.executable = true;
		this.initActive = true;
	}

	public override void Execute ()
	{
		if( dead ) return;
		TriggerTypeDetectionForNeighBours ();
	}

	private void TriggerTypeDetectionForNeighBours(){
		Vector3 p = transform.position;
		Collider2D[] up 	= Physics2D.OverlapPointAll( p + Vector3.up * 0.6f 	);
		Collider2D[] right 	= Physics2D.OverlapPointAll( p + Vector3.right * 0.5f	);
		Collider2D[] down 	= Physics2D.OverlapPointAll( p + Vector3.down * 0.6f	);
		Collider2D[] left 	= Physics2D.OverlapPointAll( p + Vector3.left * 0.5f );
		
		Transform b_up 		= FreeSpaceHelper.ThereIsSomething( up 		, transform			);
		Transform b_right 	= FreeSpaceHelper.ThereIsSomething( right 	, transform,	true);
		Transform b_left 	= FreeSpaceHelper.ThereIsSomething( left 	, transform,	true);
		Transform b_down 	= FreeSpaceHelper.ThereIsSomething( down 	, transform			);

		if( (b_up != null && b_down != null && Mathf.Abs(b_up.position.y - b_down.position.y) < 2)){
			GetComponent<Dieable>().Die();
			dead = true;
			return;
		}

		if( (b_left != null && b_right != null && Mathf.Abs(b_left.position.y - b_right.position.y) < 2)){
			GetComponent<Dieable>().Die();
			dead = true;
			return;
		}
	}
}
