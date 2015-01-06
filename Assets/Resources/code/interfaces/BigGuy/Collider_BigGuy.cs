using UnityEngine;
using System.Collections;

public class Collider_BigGuy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PolygonCollider2D p = GetComponent<PolygonCollider2D> ();
		p.points = new Vector2[]{ 
			Vector2.right/1.7f + Vector2.up/1.11f, Vector2.right/1.5f + Vector2.up/2, Vector2.right/1.5f, Vector2.right/1.7f - Vector2.up/1.2f, Vector2.right/2 - Vector2.up/1.115f,
			-Vector2.right/2 - Vector2.up/1.115f, -Vector2.right/1.7f - Vector2.up/1.2f, -Vector2.right/1.5f, -Vector2.right/1.5f + Vector2.up/2, -Vector2.right/1.7f + Vector2.up/1.11f

		};

		p.sharedMaterial = new PhysicsMaterial2D();
		p.sharedMaterial.friction = 0;
	}
}
