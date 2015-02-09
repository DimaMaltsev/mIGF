using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticleController : MonoBehaviour {
	public List<Sprite> particleSprites = new List<Sprite> ();
	public float widthRange = 10;
	public float heightRange = 10;
	public float spawnTime = 0.1f;
	public float maxParticleCount = 100;

	public float lifeTime;
	public float lifeSpeed;
	public float xSpeed;
	public float ySpeed;
	public float xSpread;
	public float ySpread;

	public float xRand;
	public float yRand;

	public float alphaSpeed;

	private List<Transform> particles = new List<Transform>();

	void Awake(){
		GetComponent<SpriteRenderer>().enabled = false;
	}

	void Start(){
		SpawnParticle ();
	}

	void Update(){
		bool removedParticle = false;

		for(int i = 0; i < particles.Count; i++ ){
			if(particles[i] == null){
				particles.RemoveAt(i);
				i--;
				removedParticle = true;
			}
		}

		if( removedParticle ){
			SpawnParticle();
		}
	}

	private void SpawnParticle(){
		if( particles.Count >= maxParticleCount ){
			return;
		}

		GameObject particle = new GameObject ("Particle");
		SpriteRenderer sr = particle.AddComponent<SpriteRenderer> ();
		sr.sprite = GetSprite ();
		sr.color = new Color (1, 1, 1, 0);

		particle.transform.position = Vector3.zero;
		particle.transform.parent = transform;
		particle.transform.localPosition = GetPosition();

		ParticleBehaviour pb = particle.AddComponent<ParticleBehaviour> ();
		pb.lifeTime = lifeTime;
		pb.xSpread = xSpread;
		pb.ySpread = ySpread;
		pb.xSpeed = xSpeed;
		pb.ySpeed = ySpeed;
		pb.xRand = xRand;
		pb.yRand = yRand;
		pb.alphaSpeed = alphaSpeed;
		pb.lifeSpeed = lifeSpeed;

		particles.Add (particle.transform);

		Invoke ("SpawnParticle", spawnTime);
	}

	private Vector3 GetPosition(){
		return new Vector3 (widthRange/2 - Random.Range(0, widthRange), heightRange/2 - Random.Range(0, heightRange), 0);
	}

	private Sprite GetSprite(){
		return particleSprites[Random.Range(0,particleSprites.Count)];
	}
}
