using UnityEngine;
using System.Collections;

public class Destructible : MonoBehaviour {
	
	public GameObject debrisPreFab;
	private Transform tornado;
	Global globalObj;
	public int destroyValue = 30;
//	Terrain tr;
//	private FavorBar favor;
	public int AngelFavor;
	public AudioClip deathknell;
	
	// Use this for initialization
	
	void Start () {
		if(GameObject.Find ("Tornado")) 
			tornado = GameObject.Find ("Tornado").transform;
		else 
			print ("Cannot find Tornado!");
//		if (GameObject.Find ("FavorBar"))
//			favor = GameObject.Find ("FavorBar").GetComponent<FavorBar>();
//		else
//			print ("Cannot find FavorBar!");
		GameObject g = GameObject.Find ("GlobalObject");
		globalObj = g.GetComponent<Global>();
		GameObject mainTerrain = GameObject.FindGameObjectWithTag("Terrain");	
		//tr = mainTerrain.GetComponent<Terrain>();
		
//		Vector3 tempVec = gameObject.transform.position;
		//tempVec.y = tr.SampleHeight(gameObject.transform.position);
		//gameObject.transform.position = tempVec;
		Physics.IgnoreLayerCollision(8,8, true);
	}

//	void OnMouseDown()
//	{
//		Die();
//	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer != 8)
		{
			if (collision.impactForceSum.magnitude > 5f)
			{			
				Die();
			}
		}
	}
	
	void Update()
	{
//		if (GameObject.FindGameObjectWithTag ("Mini"))
//			miniTornado = GameObject.FindGameObjectWithTag ("Mini").transform;
//		else
//			miniTornado = null;
		
		if(Vector3.Distance(transform.position, tornado.position) < 20f)
		{
			gameObject.rigidbody.isKinematic = false;
			Die ();
		}
		
//		else if (miniTornado != null && Vector3.Distance (transform.position,miniTornado.position) < 20f)
//		{
//			gameObject.rigidbody.isKinematic = false;
//			Die ();
//		}
		
		Transform miniTornado;
		
		GameObject[] minis = GameObject.FindGameObjectsWithTag ("Mini");
		for (int i = 0; i < minis.Length; i++)
		{
			miniTornado = minis[i].transform;
			if (Vector3.Distance (transform.position,miniTornado.position) < 20f)
			{
				gameObject.rigidbody.isKinematic = false;
				Die ();
				break;
			}
		}
	}
	
	void Die()
	{
		if (debrisPreFab)
		{
			Instantiate(debrisPreFab, transform.position, transform.rotation);
		}
//		favor.favor += AngelFavor;
		if (deathknell)
		{
			AudioSource.PlayClipAtPoint (deathknell,gameObject.transform.position);
		}
		globalObj.score += destroyValue;
		Destroy (gameObject);		
	}
	
}
