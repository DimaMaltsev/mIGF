using UnityEngine;
using System.Collections;

public class ColliderSetupper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PolygonCollider2D p = GetComponent<PolygonCollider2D> ();
		p.points = new Vector2[]{ 
			Vector2.up/2.1f, Vector2.right/3 + Vector2.up/4 , Vector2.right/2.4f, Vector2.right/2.4f - Vector2.up/6f, Vector2.right/2.6f - Vector2.up/2.2f, Vector2.right/3.5f - Vector2.up/2.1f,
			-Vector2.right/3.5f - Vector2.up/2.1f, -Vector2.right/2.6f - Vector2.up/2.2f, -Vector2.right/2.4f - Vector2.up/6f, -Vector2.right/2.4f, -Vector2.right/3 + Vector2.up/4 
		};

		CircleCollider2D c = GetComponent<CircleCollider2D> ();
		c.center = new Vector2 (0, -0.09f);
		c.radius = 0.4f;
	}
}
