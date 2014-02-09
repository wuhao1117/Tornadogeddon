using UnityEngine;
using System.Collections;

public class TornadoController : MonoBehaviour {
	
	
	public float maxSpeed = 3f;
	public Vector3 initialVelocity;
	public float healthDecrease;
	public float maxClimbAngle;	
	public bool moveable = false;
	public float frictionCoef = 0.1f;
	public GameObject[] relics;
	[HideInInspector]
	public bool onWater = false;
	[HideInInspector]
	public float waterHeight = 0f;
	[HideInInspector]
	public bool carryingRelic = false;
	
	private float tornadoSpeed;
	private Global globalObj;
	private Vector3 lastVelocity;
	private Vector3 tempPosition;
	private Vector3 differenceVelocity;
	private GameObject mainTerrain;
	private Terrain tr;
	private float lastSteepiness = 0f;
	private int relicInRadius = 0;
	private float influenceRadius;
	private GameObject relicCarried;
	private Vector3 terrainSize;
	
	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find ("GlobalObject");
		//globalObj = g.GetComponent<Global>();
		gameObject.rigidbody.velocity = initialVelocity.normalized * maxSpeed;
//		lastVelocity = gameObject.rigidbody.velocity;
		mainTerrain = GameObject.FindGameObjectWithTag("Terrain");	
		tr = mainTerrain.GetComponent<Terrain>();
		terrainSize = tr.terrainData.size;
//		print (terrainSize.x + ", " + terrainSize.z);
		influenceRadius = TornadoAffects.influenceRadius;
//		moveable = false;
		
	}
	
//	void OnDrawGizmos(){
//		Gizmos.DrawRay(transform.position + Vector3.up * 0.5f, -Vector3.up);
//	}
	// Update is called once per frame
	void FixedUpdate () {		
		
		if (!moveable)
			return;
		
		gameObject.transform.position = getGroundPosition(gameObject.transform.position);		
		RaycastHit hitInfo;
		Vector3 nextPosition = gameObject.transform.position + gameObject.rigidbody.velocity * Time.deltaTime;
		if(Physics.Raycast(nextPosition + Vector3.up * 0.5f, -Vector3.up, out hitInfo))
		{
			if(hitInfo.collider.CompareTag("Water"))
			{
				nextPosition = hitInfo.point;
			}
			if(hitInfo.collider.CompareTag("Terrain")) 
			{
				nextPosition = hitInfo.point;
			}
		}
		Vector3 diffPosition = nextPosition - gameObject.transform.position;
	
		// restrict tornaod to traverse hilly terrains but it should be able to go downhill
		Vector3 terrainLocalPos = tr.transform.InverseTransformPoint(gameObject.transform.position);
		Vector3 terrainNextLocalPos = tr.transform.InverseTransformPoint(nextPosition);
   		Vector2 normalizedPos = new Vector2(Mathf.InverseLerp(0.0f, tr.terrainData.size.x, terrainLocalPos.x),
                                     Mathf.InverseLerp(0.0f, tr.terrainData.size.z, terrainLocalPos.z));
		Vector2 normalizedNextPos = new Vector2(Mathf.InverseLerp(0.0f, tr.terrainData.size.x, terrainNextLocalPos.x),
                                     Mathf.InverseLerp(0.0f, tr.terrainData.size.z, terrainNextLocalPos.z));
		float nextSteepness = tr.terrainData.GetSteepness(normalizedNextPos.x, normalizedNextPos.y);
		Vector3 normal = tr.terrainData.GetInterpolatedNormal(normalizedPos.x, normalizedPos.y);
		Vector3 normalGrdPrj = new Vector3(normal.x, 0f, normal.z);
		if(nextSteepness > maxClimbAngle && diffPosition.y > 0f && !onWater)
		{
			Vector3 tmpVelocity = gameObject.rigidbody.velocity - normalGrdPrj.normalized * Vector3.Dot(gameObject.rigidbody.velocity, normalGrdPrj) / normalGrdPrj.magnitude;
			gameObject.rigidbody.velocity = tmpVelocity;
			
		}
		tornadoSpeed = gameObject.rigidbody.velocity.magnitude;
		tornadoSpeed = Mathf.Min(tornadoSpeed, maxSpeed);
		gameObject.rigidbody.velocity = gameObject.rigidbody.velocity.normalized * tornadoSpeed;
		
		// apply force relative to camera view
		float horizontalTilt = Input.GetAxis("Horizontal");
		float verticalTilt = Input.GetAxis("Vertical");	
		Vector3 camForward = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z).normalized;
		Vector3 camRight = Vector3.Cross(Vector3.up, camForward);
		Vector3 totalForce = horizontalTilt * camRight + verticalTilt * camForward;
		Vector3 horizontalForce =  Vector3.Project(totalForce, Vector3.right);
		Vector3 verticalForce = Vector3.Project(totalForce, Vector3.forward);
		Vector3 frictoinForce = -gameObject.rigidbody.velocity * frictionCoef;	
		gameObject.rigidbody.AddForce(horizontalForce + verticalForce + frictoinForce);
		
		// apply level boundaries
		Vector3 pos = gameObject.transform.position;
		pos.x = Mathf.Clamp(pos.x, 0f, terrainSize.x);
		pos.z = Mathf.Clamp(pos.z, 0f, terrainSize.z);
		gameObject.transform.position = pos;
	
	}
	
	void Update()
	{	
		if (!moveable)
			return;	
//		differenceVelocity = gameObject.rigidbody.velocity - lastVelocity;
//		globalObj.adjustCurrentHealth(-healthDecrease * differenceVelocity.magnitude);
//		lastVelocity = gameObject.rigidbody.velocity;
		//if(globalObj.activateTimer) globalObj.timeLeft -= Time.deltaTime;
		//if(globalObj.timeLeft < 0f) globalObj.end();
		
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if(carryingRelic && Vector3.Distance(relicCarried.transform.position, gameObject.transform.position) > influenceRadius)
					relicCarried.GetComponent<TornadoAffects>().isReleased = true;
			else
			{					
				Vector3 tornadoGroundProjection = gameObject.transform.position;
				tornadoGroundProjection.y = 0f;
				relicInRadius = 0;
				for(int i = 0; i < relics.Length; i++)
				{				
					Vector3 objGroundProjection = relics[i].transform.position;
					objGroundProjection.y = 0f;
					float distance = (tornadoGroundProjection - objGroundProjection).magnitude;	
					if(distance < influenceRadius)
					{
						relicInRadius++;
						relicCarried = relics[i];
					}
				}
				
				if(relicInRadius == 1) 
				{
					relicCarried.GetComponent<TornadoAffects>().isReleased = !relicCarried.GetComponent<TornadoAffects>().isReleased;
					if(relicCarried.GetComponent<TornadoAffects>().isReleased) print ("released!");
					else print ("captured!");
				}
			}
			
			
		}
	}
	
	Vector3 getGroundPosition(Vector3 position)
	{
		RaycastHit hitInfo;
		Vector3 grdPostion = position;
//		print (grdPostion);
		if(Physics.Raycast(position + Vector3.up * 0.5f, -Vector3.up, out hitInfo))
		{
			if(hitInfo.collider.CompareTag("Water")) {onWater = true;	grdPostion = hitInfo.point;	}		 
			if(hitInfo.collider.CompareTag("Terrain")) {onWater = false;		grdPostion = hitInfo.point;	}
			
//			print (hitInfo.collider.tag);
		}	
		return grdPostion;
	}
	
}
