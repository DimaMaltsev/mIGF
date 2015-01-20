using UnityEngine;
using System.Collections;

public class Input_BigGuy : Interface {
	private float sx = 4.5f;
	private bool canMove = true;
	private bool itIsMenu = false;
	private bool cutScene = false;

	public Input_BigGuy() : base( "sx" , "die" , "jump" , "walled" , "canpush" , "pushing" ){
		this.executable = true;
		this.initActive = true;
	}

	protected override void SetStartingValues ()
	{
		base.SetStartingValues ();

		Messenger.AddListener ("CutSceneEnd", CutSceneEnd);
		Messenger.AddListener ("CutSceneStart", CutSceneStart);
	}

	private void CutSceneEnd(){
		cutScene = false;
	}

	private void CutSceneStart(){
		cutScene = true;
		properties.SetProperty( "jump" , false );
		properties.SetProperty( "sx" , 0 );
		properties.SetProperty( "down" , false );
	}

	public override void Execute ()
	{
		if( cutScene ) return;

		if( itIsMenu ){
			properties.SetProperty( "sx" , sx );
			return;
		}

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
		PushAble[] pushable = GetPushAbleInterface();
		bool result = false;
		for(int i = 0; i < pushable.Length; i++ ){
			if( pushable[i] == null || !pushable[i].canBePushed) continue;
			result = true;
			if( direction == 1 )
				pushable[i].Push(1);
			else if( direction == -1 )
				pushable[i].Push(-1);
		}

		return result;

	}

	private PushAble[] GetPushAbleInterface(){
		float localScale = transform.localScale.x;
		PushAble[] result = new PushAble[2];
		Vector3 p1 = transform.position + localScale * Vector3.right * 0.8f - Vector3.up * 0.05f;
		Vector3 p2 = transform.position + localScale * Vector3.right * 0.8f;
		Collider2D c1 = Physics2D.OverlapPoint( p1 );
		Collider2D c2 = Physics2D.OverlapPoint( p2 );

		if( c1 != null && c1.GetComponent<PushAble>() != null )
			result[0] = c1.GetComponent<PushAble>();

		if ( c2 != null && c2.GetComponent<PushAble>() != null )
			result[1] = c2.GetComponent<PushAble>();
		return result;
	}

	private void EnableMoves(){
		canMove = true;
	}

	public void ItIsMenu(){
		itIsMenu = true;
	}
}
