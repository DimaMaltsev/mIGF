using UnityEngine;
using System.Collections;

public class FreeSpaceCheck_BigGuy : Interface {
	bool dead = false;
	public FreeSpaceCheck_BigGuy() : base(){
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
		Collider2D[] up1 	= Physics2D.OverlapPointAll( p + Vector3.up - Vector3.right * 0.5f	);
		Collider2D[] up2 	= Physics2D.OverlapPointAll( p + Vector3.up + Vector3.right * 0.5f	);

		Collider2D[] down1 	= Physics2D.OverlapPointAll( p + Vector3.down - Vector3.right * 0.5f);
		Collider2D[] down2 	= Physics2D.OverlapPointAll( p + Vector3.down + Vector3.right * 0.5f);

		Collider2D[] right1 = Physics2D.OverlapPointAll( p + Vector3.right + Vector3.up * 0.5f	);
		Collider2D[] right2 = Physics2D.OverlapPointAll( p + Vector3.right - Vector3.up * 0.5f	);

		Collider2D[] left1 	= Physics2D.OverlapPointAll( p + Vector3.left + Vector3.up * 0.5f	);
		Collider2D[] left2 	= Physics2D.OverlapPointAll( p + Vector3.left - Vector3.up * 0.5f	);
		
		Transform b_up1 = FreeSpaceHelper.ThereIsSomething (up1, transform);
		Transform b_up2 = FreeSpaceHelper.ThereIsSomething (up2, transform);

		Transform b_right1 = FreeSpaceHelper.ThereIsSomething (right1, transform, true);
		Transform b_right2 = FreeSpaceHelper.ThereIsSomething (right2, transform, true);

		Transform b_left1 = FreeSpaceHelper.ThereIsSomething (left1, transform, true);
		Transform b_left2 = FreeSpaceHelper.ThereIsSomething (left2, transform, true);

		Transform b_down1 = FreeSpaceHelper.ThereIsSomething (down1, transform);
		Transform b_down2 = FreeSpaceHelper.ThereIsSomething (down2, transform);

		if( 
		   Die ( b_up1 , b_down1 ) || 
		   Die ( b_up1 , b_down2 ) ||
		   Die ( b_up2 , b_down1 ) ||
		   Die ( b_up2 , b_down2 ) 
		   ){
			GetComponent<Dieable>().Die();
			dead = true;
			return;
		}

		if( 
		   Die ( b_left1 , b_right1, true ) || 
		   Die ( b_left1 , b_right2, true ) ||
		   Die ( b_left2 , b_right1, true ) ||
		   Die ( b_left2 , b_right2, true ) 
		   ){
			GetComponent<Dieable>().Die();
			dead = true;
			return;
		}
	}

	private bool Die( Transform one, Transform two, bool horizontal = false){
		if( one == null || two == null ) 
			return false;
		if( !horizontal ){
			return Mathf.Abs(one.position.y - two.position.y) < 2.8f;
		}
		return Mathf.Abs(one.position.x - two.position.x) < 3.1f;
	}
}
