using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
	public bool horizontal;
	public bool alwaysActive;
	public float OpenCloseSpeed;
	public float shift;

	private bool reactOnTriggers = true;

	private Vector3 shiftPoint;
	private Vector3 startPoint;
	private Vector3 goalPoint;

	void Start(){
		float x = transform.position.x + ( horizontal ? shift : 0 );
		float y = transform.position.y + ( horizontal ? 0 : shift );

		shiftPoint = new Vector3( x , y , 0 );
		startPoint = transform.position;
		goalPoint = transform.position;
	}

	void Update(){
		if( horizontal && transform.position.x == goalPoint.x ) return;
		if( !horizontal && transform.position.y== goalPoint.y ) return;

		Vector3 diff = transform.position - goalPoint;

		if( diff.magnitude <= OpenCloseSpeed * Time.deltaTime ){
			transform.position = goalPoint;
			return;
		}

		transform.position -= diff.normalized * OpenCloseSpeed * Time.deltaTime;
	}

	private void ActivateTrigger(){
		if( !reactOnTriggers ) return;
		if( !alwaysActive ) reactOnTriggers = false;

		if( goalPoint == startPoint ) goalPoint = shiftPoint;
		else if( goalPoint == shiftPoint ) goalPoint = startPoint;

	}

	private void DeActivateTrigger(){
		if( !reactOnTriggers ) return;
		if( !alwaysActive ) reactOnTriggers = false;

		if( goalPoint == startPoint ) goalPoint = shiftPoint;
		else if( goalPoint == shiftPoint ) goalPoint = startPoint;
	}


}
