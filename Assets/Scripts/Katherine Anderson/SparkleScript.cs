using UnityEngine;
using System.Collections;

public class SparkleScript : MonoBehaviour {
	
	private Transform tornado;
	Vector3 tornadoGroundProjection;
	Vector3 objGroundProjection;
	float influenceRadius = 4f;
		
	Global globalObj;
	public string nextLevel;
	
	// Use this for initialization
	void Start () {
		if(GameObject.Find ("Tornado")) 
			tornado = GameObject.Find ("Tornado").transform;
		else 
			print ("Cannot find Tornado!");
		GameObject g = GameObject.Find ("GlobalObject");
		globalObj = g.GetComponent<Global>();
	}
	
	void FixedUpdate ()
	{
		tornadoGroundProjection = tornado.position;
		tornadoGroundProjection.y = 0f;
		objGroundProjection = gameObject.transform.position;
		objGroundProjection.y = 0f;
		float distance = (tornadoGroundProjection - objGroundProjection).magnitude;	
			
		if (distance < influenceRadius)
		{
			globalObj.nextLevelName = nextLevel;
			globalObj.end();
			globalObj.arrived = true;
		}
	
	}
}
