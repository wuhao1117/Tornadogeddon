using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour
{
	private Transform tornado;
	Vector3 tornadoGroundProjection;
	Vector3 objGroundProjection;
	float influenceRadius = 4f;
	float timer;
	
	Global globalObj;
	
	// Use this for initialization
	void Start ()
	{
		if(GameObject.Find ("Tornado")) 
			tornado = GameObject.Find ("Tornado").transform;
		else 
			print ("Cannot find Tornado!");
		GameObject g = GameObject.Find ("GlobalObject");
		globalObj = g.GetComponent<Global>();
		timer = 0f;
	}
	
	void FixedUpdate ()
	{
		tornadoGroundProjection = tornado.position;
		tornadoGroundProjection.y = 0f;
		objGroundProjection = gameObject.transform.position;
		objGroundProjection.y = 0f;
		float distance = (tornadoGroundProjection - objGroundProjection).magnitude;	
		ParticleColor t = GameObject.Find ("Tornado").GetComponent<ParticleColor> ();
		//Light l = gameObject.GetComponentInChildren<Light>();
			
		if (distance < influenceRadius)
		{
			t.SetFireTornado(true);
			TornadoController c = GameObject.Find ("Tornado").GetComponent<TornadoController>();
			c.maxSpeed = 6f;
			globalObj.multiplier = 3;
			timer = 0.0f;
			ParticleRenderer[] parts = gameObject.GetComponentsInChildren<ParticleRenderer>();
			for (int i = 0; i < parts.Length; i++)
			{
				parts[i].enabled = false;	
			}
			//l.enabled = false;
		}
		
		if (t.fireTornado == true)
		{
			timer += Time.deltaTime;
		}
		
		if (timer > 10f)
		{
			t.SetFireTornado(false);
			TornadoController c = GameObject.Find ("Tornado").GetComponent<TornadoController>();
			c.maxSpeed = 3f;
			globalObj.multiplier = 1;
			Destroy (gameObject);
		}
	}
}

