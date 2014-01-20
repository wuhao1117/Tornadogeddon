using UnityEngine;
using System.Collections;

public class SharkScript : MonoBehaviour {

	private float lifeTimer = 0.0f;
	private float dyingTimer = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lifeTimer += Time.deltaTime;
		
		if (lifeTimer > 6.0f)
		{
			Die ();
		}
		
	}
	
	void OnCollisionEnter(Collision collision)
	{
	}
	void Die()
	{
		Destroy(gameObject);
	}
}