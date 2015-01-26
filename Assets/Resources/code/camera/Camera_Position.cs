using UnityEngine;
using System.Collections;

public class Camera_Position : MonoBehaviour {
	private Transform bigGuy;
	private Transform smallGuy;
	private Vector2 cameraShift;
	private Vector2 freezePoint;

	private Camera camera;
	private bool cameraFrozen = false;
	private bool cutSceneOn = false;
	private bool freezeOnPoint = false;


	private float lastDiff = 0;

	public bool verticalConstraint = false;
	public bool fireEveryOneBlockEvent = false;
	public string musicName = "";

	void Awake(){
		camera = GetComponent<Camera>();
		float red = Mathf.Floor(64000 / 255)/1000;
		float green = Mathf.Floor(79000 / 255)/1000;
		float blue = Mathf.Floor(61000 / 255)/1000;
		Color r = new Color (red, green, blue);
		camera.backgroundColor = r;///new Color (64/255,79/255,61/255);
		Messenger.AddListener<Transform>( "SmallGuySpawned" , OnSmallGuySpawned );
		Messenger.AddListener<Transform>( "BigGuySpawned" 	, OnBigGuySpawned 	);
		Messenger.AddListener<float>( "FreezeCamera" , OnFreezeCamera );
		Messenger.AddListener<Vector2>( "CutSceneCameraShift" , OnCutSceneCameraShift );
		Messenger.AddListener( "CutSceneStart" , OnCutSceneStart );
		Messenger.AddListener( "CutSceneEnd" , OnCutSceneEnd );
		Messenger.AddListener<Vector2>( "FreezeOnPoint" , FreezeOnPoint );
		Messenger.AddListener( "DeFreezeOnPoint" , DeFreezeOnPoint );
		
		AudioSource audioSource = GetComponent<AudioSource> ();
		GameObject soundLibGameObj = GameObject.FindGameObjectWithTag( "SoundLibrary" );
		if( soundLibGameObj != null ){
			SoundLibrary soundLibrary = soundLibGameObj.GetComponent<SoundLibrary>();
			
			if (musicName != "" ){
				AudioClip sound = soundLibrary.GetSound( musicName , audioSource , "music" );
				audioSource.clip = sound;
				audioSource.Play ();
			}
		}
	}


	void Update () {
		if( cameraFrozen ) return;

		Vector3 pos = Vector3.zero;
		int coef = 0;
		if( bigGuy 		!= null ){ pos += bigGuy.position; 		coef ++; }
		if( smallGuy 	!= null ){ pos += smallGuy.position; 	coef ++; }
	
		if( coef == 0 ) return;

		Vector3 shift = new Vector3 (cameraShift.x, cameraShift.y, 0);

		Vector3 finalPos = Vector3.zero;
		if( freezeOnPoint ){
			finalPos = new Vector3( freezePoint.x, freezePoint.y, transform.position.z);
		}else{
			finalPos = pos / coef - Vector3.forward * 10 + shift;
		}
		if( verticalConstraint ) finalPos = new Vector3(finalPos.x , transform.position.y , finalPos.z );

		if(cutSceneOn || freezeOnPoint){
			if((finalPos - transform.position).magnitude > 2 ){
				finalPos = transform.position + (finalPos - transform.position).normalized * 2;
			}
		}

		Vector3 newPos = Vector3.Lerp( transform.position , finalPos , Time.deltaTime * 10 );
		lastDiff += newPos.x - transform.position.x;
		transform.position = newPos;

		if( Mathf.Abs(lastDiff) >= 1 ){
			if( fireEveryOneBlockEvent ){
				Messenger.Broadcast("CameraOneBlockStep");
			}
			lastDiff = lastDiff - 1;
		}
	}

	private void OnSmallGuySpawned( Transform smallGuy ){
		this.smallGuy = smallGuy;
	}

	private void OnBigGuySpawned( Transform bigGuy ){
		this.bigGuy = bigGuy;
	}

	private void OnFreezeCamera( float time ){
		cameraFrozen = true;
		if( IsInvoking( "UnfreezeCamera" ) )
			CancelInvoke( "UnfreezeCamera" );
		Invoke ( "UnfreezeCamera" , time );
	}

	private void UnfreezeCamera(){
		cameraFrozen = false;
	}

	private void OnCutSceneCameraShift(Vector2 shift){
		cameraShift = shift;
	}
	private void OnCutSceneStart(){
		if( freezeOnPoint ) return;

		cutSceneOn = true;
	}
	private void OnCutSceneEnd(){
		if( freezeOnPoint ) return;

		cameraShift = Vector2.zero;
		cutSceneOn = false;
	}

	private void FreezeOnPoint(Vector2 point){
		if( cutSceneOn ) return;

		freezeOnPoint = true;
	}
	private void DeFreezeOnPoint(){
		if( cutSceneOn ) return;

		freezeOnPoint = false;
	}
}
