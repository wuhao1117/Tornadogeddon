using UnityEngine;
using System.Collections;

public class CheckSparkle : MonoBehaviour {
	
	public Transform sparkle;
	Vector3 sparkleGroundProjection;
	Vector3 objGroundProjection;
	float influenceRadius = 2f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate () {
		sparkleGroundProjection = sparkle.position;
		sparkleGroundProjection.y = 0f;
		objGroundProjection = gameObject.transform.position;
		objGroundProjection.y = 0f;
		float distance = (sparkleGroundProjection - objGroundProjection).magnitude;	
			
		if (distance < influenceRadius)
		{
			print ("It's in there!");
		}
		
	}
}
