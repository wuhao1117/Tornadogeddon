using UnityEngine;
using System.Collections;

public class AngelBeacon : MonoBehaviour {

	// Use this for initialization
	public bool isActive;
	private ParticleSystem ps;
	void Start () {
		ps = GetComponent<ParticleSystem>();
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void Active(bool active)
	{
//		if (active)
//		{
//			particleSystem.Play();
//			particleSystem.enableEmission = active;
//			renderer.enabled = !active;
//			light.enabled = !active;
		ps.enableEmission = true;
		ps.Play();
			
//		}
	}
}
