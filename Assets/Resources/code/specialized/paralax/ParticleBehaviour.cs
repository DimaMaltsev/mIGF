using UnityEngine;
using System.Collections;

public class ParticleBehaviour : MonoBehaviour {
	public float lifeTime;
	public float lifeSpeed;
	public float xSpread;
	public float ySpread;
	public float xSpeed;
	public float ySpeed;
	public float xRand;
	public float yRand;
	public float alphaSpeed;

	private bool living = true;
	private float targetAlpha = 1;
	private SpriteRenderer spriteRender;
	private float sign = 1;

	private float upperAlpha = 1;
	private float lowerAlpha = 0.5f;
	private bool grownParticle = false;

	private float xDiff;
	private float yDiff;

	void Awake(){
		spriteRender = GetComponent<SpriteRenderer> ();
	}

	void Start(){
		xDiff = xSpeed / 2 - Random.Range (0.0f, xSpeed) + xSpread;
		yDiff = ySpeed / 2 - Random.Range (0.0f, ySpeed) + ySpread;
	}

	void Update () {
		if(lifeTime >= 0 && living){
			lifeTime -= lifeSpeed;
		}else{			
			living = false;
			sign =-1;
		}

		float alpha = spriteRender.color.a;
		alpha += alphaSpeed * sign;

		if( living && alpha > upperAlpha && grownParticle ){
			sign = -1;
		}

		if( living && alpha < lowerAlpha && grownParticle ){
			sign = 1;
		}

		if( !grownParticle && alpha > lowerAlpha ){
			grownParticle = true;
		}

		if (!living && alpha < 0) {
			Destroy(gameObject);
		}

		spriteRender.color = Color.Lerp (spriteRender.color, new Color (1, 1, 1, alpha), Time.deltaTime * 10);
		
		float xrnd = Random.Range (-xRand, xRand);
		float yrnd = Random.Range (-yRand, yRand);

		Vector3 position = transform.position;
		Vector3 newPosition = new Vector3(position.x + xDiff + xrnd , position.y + yDiff + yrnd, 0);

		transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 10);
	}
}
