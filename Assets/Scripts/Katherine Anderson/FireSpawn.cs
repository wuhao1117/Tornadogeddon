using UnityEngine;
using System.Collections;

public class FireSpawn : MonoBehaviour
{
	public GameObject firePrefab;
	private Transform tornado;
	
	// Use this for initialization
	void Start ()
	{
		if(GameObject.Find ("Tornado")) 
			tornado = GameObject.Find ("Tornado").transform;
		else 
			print ("Cannot find Tornado!");
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.impactForceSum.magnitude > 1.0f)
		{			
			Die();
		}
	}
	
	void Update()
	{
		if(Vector3.Distance(transform.position, tornado.position) < 5f)
			Die ();
	}
	
	void Die()
	{
		float rand = Random.value * 100f;
		if (rand <= 5.0f && firePrefab)
		{
			Instantiate(firePrefab, transform.position, transform.rotation);
		}
	}
}

