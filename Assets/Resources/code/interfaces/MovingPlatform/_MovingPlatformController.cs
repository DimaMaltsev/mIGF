using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class _MovingPlatformController : Interface {
	public List<Vector3> points = new List<Vector3>();
	public bool reactOnButtonOn;
	public bool reactOnButtonOff;
	public int reactCountLimit;
	public float speed;
	public bool moving;
	public float reactDelay;

	private bool stoping = false;
	private int reactCount = 0;

	public _MovingPlatformController() : base( "sx" , "sy" , "onplatform" ){
		this.initActive = true;
		this.executable = true;
	}

	protected override void SetStartingValues ()
	{
		properties.SetProperty( "onplatform" , 0 );
		Vector3 p = transform.position;
		for( int i = 0 ; i < points.Count ; i++ ){
			points[ i ] = new Vector3( p.x + points[ i ].x , p.y + points[ i ].y  , points[ i ].z );
		}

		points.Add (transform.position);
	}

	public override void Execute ()
	{
		ColorBlocksInside ();
		if( !moving ) return;

		Vector3 p 		= transform.position;
		Vector3 delta 	= points [0] - p;
		Vector3 shift 	= delta.normalized * speed;

		if( delta.magnitude < speed * Time.deltaTime ){
			transform.position = points[0];
			shift = Vector3.zero;
			ShiftPoint();
			if( stoping ){
				moving = false;
				stoping = false;
			}
		}else{
			transform.position += shift * Time.deltaTime;
			transform.position = new Vector3(transform.position.x, transform.position.y , 0);
		}

		properties.SetProperty ("sx", shift.x);
		properties.SetProperty ("sy", shift.y);
	}

	private void ShiftPoint(){
		points.Add(points[0]);
		points.RemoveAt (0);
	}

	private void DisableMoving(){
		stoping = true;
	}

	private void EnableMoving(){
		moving = true;
		stoping = false;
	}

	private void EnableDisableMoving(){
		reactCount++;
		if(!moving || stoping){
			EnableMoving();
		}else{
			DisableMoving();
		}
	}

	private void ColorBlocksInside( bool paintRed = false ){
		for(int i = 0 ; i < transform.childCount; i++ ){
			SpriteRenderer sprite = transform.GetChild( i ).GetComponent<SpriteRenderer>();

			if( !paintRed ){
				if( sprite.color != Color.white )
					sprite.color = Color.Lerp( sprite.color , Color.white , Time.deltaTime * 10 );
			}else{
				sprite.color = Color.red;
			}
		}
	}

	private bool CanReact(string type){
		if( reactCountLimit != 0 && reactCount >= reactCountLimit )
			return false;

		switch(type){
		case "ON": 
			return reactOnButtonOn;
			break;
		case "OFF": 
			return reactOnButtonOff;
			break;
		}
		return false;
	}

	private void ButtonReaction(){
		if( reactDelay == 0 ){
			EnableDisableMoving ();
		}else{
			if( IsInvoking ( "EnableDisableMoving" ) ){
				CancelInvoke( "EnableDisableMoving" );
			}
			Invoke ( "EnableDisableMoving" , reactDelay );
		}
	}

	private void ActivateTrigger(){
		if(!CanReact("ON")){
			ColorBlocksInside( true );
			return;
		}
		ButtonReaction ();
	}

	private void DeActivateTrigger(){
		if(!CanReact("OFF")){
			ColorBlocksInside( true );
			return;
		}
		ButtonReaction ();
	}
}
