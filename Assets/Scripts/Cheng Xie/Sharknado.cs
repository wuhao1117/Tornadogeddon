using UnityEngine;
using System.Collections;

public class Sharknado : MonoBehaviour {

	// Use this for initialization
	private float sharkSpawnTime;
	public GameObject sharkPrefab;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		sharkSpawnTime += Time.deltaTime;
		
		if (sharkSpawnTime > 0.75f)
		{
			SpawnShark();
		}
	}
	
	void SpawnShark()
	{
		float randomX, randomY, randomZ;
		randomX = Random.Range(-360,360);
		randomY = Random.Range(-90,45);
		randomZ = Random.Range(-360,360);		
//		randomX = Random.Range(0,360);
//		randomY = Random.Range(-180,45);
//		randomZ = Random.Range(0,360);
		 
		float randomSpawnY = Random.Range (5, 25);
		
		Vector3 SpawnY = transform.position + new Vector3(0,randomSpawnY,0);
		
		Vector3 direction = new Vector3(randomX, randomY, randomZ);
		direction.Normalize();
		
		GameObject shark = Instantiate(sharkPrefab, SpawnY, transform.rotation) as GameObject;
		
		shark.rigidbody.velocity = direction * 70;
		shark.transform.forward = direction;
		
		sharkSpawnTime = 0.0f;		
		
	}	
}
