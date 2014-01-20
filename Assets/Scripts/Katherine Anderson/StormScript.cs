using UnityEngine;
using System.Collections;

public class StormScript : MonoBehaviour
{
	private Transform tornado;
	Vector3 tornadoGroundProjection;
	Vector3 objGroundProjection;
	float influenceRadius = 8f;
	float timer;
	
	Global globalObj;
	ParticleSystem storm;
	
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
		storm = gameObject.GetComponent<ParticleSystem>();
	}
	
	void FixedUpdate ()
	{
		tornadoGroundProjection = tornado.position;
		tornadoGroundProjection.y = 0f;
		objGroundProjection = gameObject.transform.position;
		objGroundProjection.y = 0f;
		float distance = (tornadoGroundProjection - objGroundProjection).magnitude;	
		ParticleColor t = GameObject.Find ("Tornado").GetComponent<ParticleColor> ();
			
		if (distance < influenceRadius && storm.renderer.enabled == true)
		{
			t.SetLightningTornado(true);
			timer = 0.0f;
			storm.renderer.enabled = false;
		}
		if (t.lightningTornado == true)
		{
			timer += Time.deltaTime;
		}
		if (timer > 10f)
		{
			t.SetLightningTornado(false);
			Destroy(gameObject);
		}
	}
}

