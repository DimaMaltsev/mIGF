using UnityEngine;
using System.Collections;

public class Collider_BigGuy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PolygonCollider2D p = GetComponent<PolygonCollider2D> ();
		p.points = new Vector2[]{ 
			Vector2.up , Vector2.right/1.5f + Vector2.up/2, Vector2.right/1.5f, Vector2.right/1.7f - Vector2.up/1.2f, Vector2.right/2 - Vector2.up/1.1f,
			-Vector2.right/2 - Vector2.up/1.1f, -Vector2.right/1.7f - Vector2.up/1.2f, -Vector2.right/1.5f, -Vector2.right/1.5f + Vector2.up/2

		};

		p.sharedMaterial = new PhysicsMaterial2D();
		p.sharedMaterial.friction = 0;
		//CircleCollider2D c = GetComponent<CircleCollider2D> ();
		//c.center = new Vector2 (0, -0.09f);
		//c.radius = 0.4f;
	}
}
