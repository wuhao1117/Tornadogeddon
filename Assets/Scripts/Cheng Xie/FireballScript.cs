using UnityEngine;
using System.Collections;

public class FireballScript : MonoBehaviour {
	
	private float lifeTimer = 0.0f;
	private float dyingTimer = 0.0f;
	private bool dying = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lifeTimer += Time.deltaTime;
		
		if (lifeTimer > 2.0f)
		{
			StopFire();
		}
		
		if (dying)
		{
			dyingTimer += Time.deltaTime;
//			ParticleSystem smokeTrail = gameObject.GetComponentInChildren<ParticleSystem>();
//			smokeTrail.enableEmission = false;
//			smokeTrail.renderer.enabled = false;
			if (dyingTimer > 2.0f)
			{
				Die ();
			}
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer != 11)
		{			
			StopFire();
		}
	}
	
	void StopFire()
	{
		//Destroy(gameObject);
		gameObject.rigidbody.velocity = Vector3.zero;
		gameObject.renderer.enabled = false;
		gameObject.particleSystem.enableEmission = false;
		dying = true;
	}
	
	void Die()
	{
		Destroy(gameObject);
	}
}
