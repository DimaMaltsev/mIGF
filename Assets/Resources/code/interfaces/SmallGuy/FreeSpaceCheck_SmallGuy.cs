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
		Collider2D[] up 	= Physics2D.OverlapPointAll( p + Vector3.up * 0.6f 	);
		Collider2D[] right 	= Physics2D.OverlapPointAll( p + Vector3.right * 0.5f	);
		Collider2D[] down 	= Physics2D.OverlapPointAll( p + Vector3.down * 0.6f	);
		Collider2D[] left 	= Physics2D.OverlapPointAll( p + Vector3.left * 0.5f );
		
		int b_up 		= ThereIsSomething( up 	);
		int b_right 	= ThereIsSomething( right 	, true);
		int b_left 	= ThereIsSomething( left 	, true);
		int b_down 	= ThereIsSomething( down 	);

		if( b_up + b_down > 0 || b_left + b_right > 0 ){
			GetComponent<Dieable>().Die();
		}
	}

	private int ThereIsSomething( Collider2D[] others , bool horizontal = false){ // 0 - static block, 1 - moving block, -1 - nothing
		if( others != null ){
			for( int i = 0 ; i < others.Length; i++ ){
				Collider2D block = others[ i ];
				if( block.GetComponent<Block_TypeDetection>() != null && SimpleBlock(block)) {
					return 0;
				}else if(block.GetComponent<Block_TypeDetection>() != null && !SimpleBlock(block)){
					return 1;
				}

				if( block.GetComponent<Box_Moves>() != null && block.GetComponent<ObjectController>().propertyFacade.GetPropertyNumber(horizontal ? "sx" : "sy")!=0) return 1;
				if( block.GetComponent<Box_Moves>() != null && block.GetComponent<ObjectController>().propertyFacade.GetPropertyNumber(horizontal ? "sx" : "sy")==0) return 0;

				if( block.GetComponent<DoorController>() != null ) return 1;
				if( block.GetComponent<CrumblingWallController>() != null ) return 1;
			}
		}
		
		return -1;
	}

	private bool SimpleBlock(Collider2D block){
		Transform tr = block.transform;
		return tr.parent == null || (tr.parent.GetComponent<MovingPlatformController> () == null && tr.parent.GetComponent<_MovingPlatformController> () == null);
	}
}
