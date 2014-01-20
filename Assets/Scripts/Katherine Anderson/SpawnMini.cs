using UnityEngine;
using System.Collections;

public class SpawnMini : MonoBehaviour {

	public GameObject miniTornado;
	private float timing;
	
	// Use this for initialization
	void Start () {
		timing = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		timing += Time.deltaTime;
		if (timing >= 1.0f)
		{
//			if (!GameObject.FindGameObjectWithTag ("Mini"))
//			{
				Instantiate (miniTornado, transform.position, transform.rotation);	
				timing = 0.0f;
//			}
		}
	
	}
}
