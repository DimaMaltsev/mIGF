using UnityEngine;
using System.Collections;

public class Input_BigGuy : Interface {
	private float sx = 4;
	private bool canMove = true;
	public Input_BigGuy() : base( "sx" , "die" , "jump" , "walled" , "canpush" , "pushing" ){
		this.executable = true;
		this.initActive = true;
	}

	public override void Execute ()
	{
		int direction = 0;
		if( !canMove ) return;

		if( Input.GetButton( "Right" ) ) direction ++;
		if( Input.GetButton( "Left" ) ) direction --;
		
		if( Input.GetButtonDown( "Up" ) ) 	properties.SetProperty( "jump" , true );
		if( Input.GetButtonUp( "Up" ) ) 	properties.SetProperty( "jump" , false );

		properties.SetProperty( "down" , Input.GetButton( "Down" ) );

		if( Input.GetButton( "Jump" ) )	GetComponent<Dieable>().Die();

		bool walled = properties.GetPropertyBoolean( "walled" ) &&
			transform.localScale.x == direction;

		bool canpush = properties.GetPropertyBoolean( "canpush" ) &&
			transform.localScale.x == direction;
		
		if( canpush ){ 
			if( MoveCube( direction ) ){
				if( direction != 0 ){
					properties.SetProperty( "pushing" , true );
					canMove = false;
					properties.SetProperty( "sx" , 0 );
					Invoke( "EnableMoves" , 0.2f );
					return;
				}
				else properties.SetProperty( "pushing" , false );
			}else direction = 0;
		}else properties.SetProperty( "pushing" , false );

		if( walled ) direction = 0;

		properties.SetProperty( "sx" , direction * sx );
	}

	private bool MoveCube( int direction ) {
		PushAble ps = GetPushAbleInterface();
		if( ps == null ) return false;

		if( direction == 1 )
			ps.Push(1);
		else if( direction == -1 )
			ps.Push(-1);

		return true;

	}

	private PushAble GetPushAbleInterface(){
		float localScale = transform.localScale.x;
		Vector3 p1 = transform.position + localScale * Vector3.right * 0.7f;
		Vector3 p2 = transform.position + localScale * Vector3.right * 0.7f + Vector3.up;
		Collider2D c1 = Physics2D.OverlapPoint( p1 );
		Collider2D c2 = Physics2D.OverlapPoint( p2 );

		if( c1 != null && c1.GetComponent<PushAble>() != null )
			return c1.GetComponent<PushAble>();

		if ( c2 != null && c2.GetComponent<PushAble>() != null )
			return c2.GetComponent<PushAble>();
		return null;
	}

	private void EnableMoves(){
		canMove = true;
	}
}
