using UnityEngine;
using System.Collections;

public class FireTornado : MonoBehaviour {

	// Use this for initialization
	private float fireballSpawnTime;
	public GameObject fireballPrefab;
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		fireballSpawnTime += Time.deltaTime;
		
		if (fireballSpawnTime > 0.75f)
		{
			SpawnFireball();
		}
		
	}
	
	void SpawnFireball()
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
		
		GameObject fireball = Instantiate(fireballPrefab, SpawnY, transform.rotation) as GameObject;
		
		fireball.rigidbody.velocity = direction * 70;
		
		fireballSpawnTime = 0.0f;
		
		
	}
}
