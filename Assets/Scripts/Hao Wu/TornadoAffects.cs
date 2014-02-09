using UnityEngine;
using System.Collections;

public class TornadoAffects : MonoBehaviour {
	
	public bool isRelic = false;
	public bool isReleased = false;	
	[HideInInspector]
	public static float influenceRadius = 20f;
	
	private GameObject tornado;
	private float referenceHeight;
	private Vector3 tornadoGroundProjection;
	private Vector3 objGroundProjection;
	
	private Vector3 tangentForce;		
	private Vector3 attractForce;
	private Vector3 liftForce;
	
	private float tornadoHeight = 50f;	
	private float characteristicDistance = 5f;
	private float attractStrength = 50f;
	private float MaxTangentStrength = 6f;
	private float liftStrength = 5f;
	
	
	private Global globalObj;
//	public int suctionValue = 10;
	private float deathCountDown = 0f;
	private float deathTimer = 0f;
	private bool isAffected = false;
	private Vector3 terrainSize;
	
	void Start()
	{
		if(GameObject.Find ("Tornado")) 
			tornado = GameObject.Find ("Tornado");
		else 
			print ("Cannot find Tornado!");
	
		if(GameObject.Find ("ReferencePlane")) 
		{
			GameObject ReferencePlane = GameObject.Find ("ReferencePlane");
			referenceHeight = ReferencePlane.transform.position.y;
			tornadoHeight += referenceHeight;
		}
			
		else 
			print ("Cannot find ReferencePlane!");
		GameObject g = GameObject.Find ("GlobalObject");
		//globalObj = g.GetComponent<Global>();
		//if(!isRelic) globalObj.debrisQueue.Enqueue(gameObject);
		deathCountDown = Random.Range(5f, 20f);
		deathTimer = 0f;
		isAffected = false;
		terrainSize = GameObject.FindGameObjectWithTag("Terrain").GetComponent<Terrain>().terrainData.size;	
	}
	
	void FixedUpdate()
	{
		tornadoGroundProjection = tornado.transform.position;
		tornadoGroundProjection.y = 0f;
		objGroundProjection = gameObject.transform.position;
		objGroundProjection.y = 0f;
		float distance = (tornadoGroundProjection - objGroundProjection).magnitude;	
		
		if(!isReleased)
		{
//			if(isAffected && !isRelic) deathTimer += Time.fixedDeltaTime;
//			if(deathTimer > deathCountDown) Destroy(gameObject);
//			else
//			{				
			attractForce = (tornadoGroundProjection - objGroundProjection).normalized;
			attractForce *= (distance < influenceRadius)? attractStrength / 2f * Mathf.Exp(-distance / attractStrength) : 0f;
			//attractForce *= (distance < influenceRadius)? LJForceCal(distance, characteristicDistance) : 0f;
			
			tangentForce = Vector3.Cross(this.attractForce, Vector3.up).normalized * RankineVortexCal(distance, characteristicDistance);
					
			liftForce.y = Mathf.Exp(-distance/liftStrength) * ((30f + referenceHeight) / (gameObject.transform.position.y + 1e-6f)) * gameObject.rigidbody.mass * Physics.gravity.magnitude;
			//liftForce.y = liftStrength * Mathf.Exp (-distance / liftStrength) * Mathf.Exp (-gameObject.transform.position.y / liftStrength)* gameObject.rigidbody.mass * Physics.gravity.magnitude;
			liftForce.x = 0f;
			liftForce.z = 0f;
			
			if (distance < influenceRadius)
			{
				if(!isAffected) 
				{
					isAffected = true;
//					globalObj.score += suctionValue;
				}
				if (gameObject.transform.position.y > tornadoHeight)
				{
					gameObject.rigidbody.AddForce(this.tangentForce * 0.5f + Vector3.up * -50f);
				}
				else
				{
					//gameObject.rigidbody.AddForce(this.attractForce * 2f + this.liftForce * 0.9f + this.tangentForce * 0.05f);
					gameObject.rigidbody.AddForce(this.attractForce + this.liftForce + this.tangentForce);
				}
			}
//			}	
		}
		// apply level boundaries
		if (gameObject.CompareTag("Relic"))
		{
			Vector3 pos = gameObject.transform.position;
			pos.x = Mathf.Clamp(pos.x, 0f, terrainSize.x);
			pos.z = Mathf.Clamp(pos.z, 0f, terrainSize.z);
			gameObject.transform.position = pos;
		}
	}

	
	float RankineVortexCal(float radialDistance, float charDistance)
	{
		float modRadialDistance = Mathf.Abs(radialDistance);
		float modeCharDistance = Mathf.Abs(charDistance);
		if(modRadialDistance < modeCharDistance)
			return MaxTangentStrength * (modRadialDistance / (modeCharDistance + 1e-6f));
		else
			return MaxTangentStrength * (modeCharDistance/ (modRadialDistance + 1e-6f));
	}
	
	float LJForceCal(float radialDistance, float charDistance)
	{
		float modRadialDistance = Mathf.Abs(radialDistance) / (charDistance);
		float modeCharDistance = Mathf.Abs(charDistance);
		float reproDistSq = 1f / (modRadialDistance * modRadialDistance);
		return (modRadialDistance > 1f) ? -attractStrength * reproDistSq * (reproDistSq - 1) : 0f;
	}
}
