using UnityEngine;
using System.Collections;

public class DropOffField : MonoBehaviour {
	
	public float dropOffRadius;
	public float dropOffHeight;
	public float posDampening = 0.01f;
	public float rotDampening = 1f;
	public int relicLayer;
	
	private Global globalObj;
	private bool activated = true;
	private bool relocating = false;
	private bool descend = false;
	private bool settled = false;
	private RaycastHit hitInfo;
	private GameObject capturedRelic;
	private Transform relicTransform;
	private Vector3 dropOffPosition;
	private Vector3 relicPosition;
	private Quaternion relicRotation;
	private Quaternion finalRotation;
	private Vector3 finalPosition;
	private Vector3 centerPosition;
	private Terrain tr;
	
	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find ("GlobalObject");
		globalObj = g.GetComponent<Global>();
		GameObject mainTerrain = GameObject.FindGameObjectWithTag("Terrain");	
		tr = mainTerrain.GetComponent<Terrain>();
		dropOffPosition = gameObject.transform.position;
		finalRotation = Quaternion.identity;	
		float terrainHeight = tr.SampleHeight(gameObject.transform.position);
		Vector3 tempVec = gameObject.transform.position;
		tempVec.y = terrainHeight;
		gameObject.transform.position = tempVec;
	}
	
	// Update is called once per frame
	void Update () {
		if(activated && Physics.SphereCast(gameObject.transform.position, dropOffRadius, Vector3.up, out hitInfo, dropOffHeight, 1 << relicLayer))
		{
			if(hitInfo.collider.CompareTag("Relic") && hitInfo.collider.gameObject.GetComponent<TornadoAffects>().isReleased)
			{
				activated = false;
				relocating = true;
				capturedRelic = hitInfo.collider.gameObject;
				relicTransform = capturedRelic.transform;
				capturedRelic.rigidbody.isKinematic = true;
				relicPosition = relicTransform.position;
				relicRotation = relicTransform.rotation;
				centerPosition = new Vector3(dropOffPosition.x, relicPosition.y, dropOffPosition.z);
				finalPosition = new Vector3(dropOffPosition.x, dropOffPosition.y, dropOffPosition.z);				
				if(hitInfo.collider.name == "DeathStatue")
					globalObj.timeLeft += 30;
				else
					globalObj.score += 1000;
			}
			
		}
		
		if(relocating)
		{
			if(Vector3.Distance(relicPosition, centerPosition) < 0.1f)
			{
				relocating = false;
				descend = true;
			}
			else
			{
				relicPosition = Vector3.Lerp(relicPosition, centerPosition, Time.deltaTime * posDampening);
				relicTransform.position = relicPosition;
				relicRotation = Quaternion.Lerp(relicRotation, finalRotation, Time.deltaTime * rotDampening);
				relicTransform.rotation = relicRotation;
			}
		}
		
		if(descend)
		{
			if(Vector3.Distance(relicPosition, finalPosition) < 0.1f)
			{
				descend = false;
				settled = true;
			}
			else
			{
				relicPosition = Vector3.Lerp(relicPosition, finalPosition, Time.deltaTime * posDampening);
				relicTransform.position = relicPosition;
			}
			
		}
		
		if(settled)
		{
			if(hitInfo.collider.name == "AngelBeacon") capturedRelic.GetComponent<AngelBeacon>().Active(true);
			settled = false;
		}
		
	
	}
}
