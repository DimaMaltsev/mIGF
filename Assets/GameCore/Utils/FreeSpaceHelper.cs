using UnityEngine;
using System.Collections;

public static class FreeSpaceHelper {

	public static Transform ThereIsSomething( Collider2D[] others , Transform transform, bool horizontal = false){
		if( others != null ){
			for( int i = 0 ; i < others.Length; i++ ){
				Collider2D block = others[ i ];
				
				if( block.GetComponent<Box_Moves>() != null && Dangerous(block.transform, horizontal, transform)) 
					return block.transform;
				
				if( block.transform.parent ){
					Transform par = block.transform.parent;
					bool movingPlatform = 
						par.GetComponent<MovingPlatformController>() != null || 
						par.GetComponent<_MovingPlatformController>()!= null;
					
					if( movingPlatform ){
						if( Dangerous(block.transform, horizontal, transform ) )
							return block.transform;
					}else{					
						if( block.GetComponent<Block_TypeDetection>() != null ) return block.transform;
					}
				}
				
				if( block.GetComponent<DoorController>() != null ) return block.transform;
				if( block.GetComponent<CrumblingWallController>() != null ) return block.transform;				
			}
		}
		
		return null;
	}
	
	private static bool Dangerous(Transform tr, bool horizontal, Transform transform ){
		Transform parent = tr.parent;
		
		float sx = parent.GetComponent<ObjectController>().propertyFacade.GetPropertyNumber("sx");
		float sy = parent.GetComponent<ObjectController>().propertyFacade.GetPropertyNumber("sy");
		
		if( sx != 0 && horizontal ){
			float delta = transform.position.x - tr.position.x;
			return HeIsMovingOnMe( delta, sx );
		}
		
		if( sy != 0 && !horizontal ){
			float delta = transform.position.y - tr.position.y;
			return HeIsMovingOnMe( delta, sy );
		}
		
		return false;
	}
	
	private static bool HeIsMovingOnMe(float delta, float speed){		
		return Mathf.Sign (delta) == Mathf.Sign (speed);
	}
}
