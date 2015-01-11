using UnityEngine;
using System.Collections;

public class ParalaxLevelController : MonoBehaviour {

	public float horizontalAffection;
	public float verticalAffection;

	public float contentDuplicationShift = 24.3f;

	private float totalHorShift;
	private Transform c0;
	private Transform c1;
	private Transform c2;

	void Start () {
		CreateLayerDuplications ();
		totalHorShift = 0;
	}

	void Update () {
	
	}

	private void CreateLayerDuplications(){
		Transform c1 = transform.FindChild ("Content");
		c1.gameObject.name = "1";
		Transform c0 = (Transform)Instantiate (c1);
		Transform c2 = (Transform)Instantiate (c1);

		c0.name = "0";
		c2.name = "2";

		c0.parent = transform;
		c2.parent = transform;
		
		c0.position = c1.position - Vector3.right * contentDuplicationShift;
		c2.position = c1.position + Vector3.right * contentDuplicationShift;
	}

	private void ChangeContentPositions(){
		Transform c0 = transform.FindChild("0");
		Transform c1 = transform.FindChild("1");
		Transform c2 = transform.FindChild("2");

		if( totalHorShift < 0 ){
			c0.transform.position = c2.transform.position + contentDuplicationShift * Vector3.right;
			c0.name = "2";
			c1.name = "0";
			c2.name = "1";
		}else{
			c2.transform.position = c0.transform.position - contentDuplicationShift * Vector3.right;
			c0.name = "1";
			c1.name = "2";
			c2.name = "0";
		}

		totalHorShift += -Mathf.Sign(totalHorShift) * contentDuplicationShift;
		if( Mathf.Abs( totalHorShift ) >= contentDuplicationShift){
			ChangeContentPositions();
		} 
	}

	public void CameraMove(Vector3 diff){
		totalHorShift -= diff.x * horizontalAffection/10;
		transform.position -= Vector3.right * diff.x * horizontalAffection/10;

		if( Mathf.Abs( totalHorShift ) >= contentDuplicationShift){
			ChangeContentPositions();
		}
	}
}
