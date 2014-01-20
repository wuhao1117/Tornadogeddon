using UnityEngine;
using System.Collections;

public class MiniTornadoScript : MonoBehaviour {

	public float maxSpeed = 64f;
	public Vector3 initialVelocity;
	public float healthDecrease;
	public float maxClimbAngle;	
	public bool moveable = false;
	public float frictionCoef = 0.1f;
	[HideInInspector]
	public bool onWater = false;
	[HideInInspector]
	public float waterHeight = 0f;
	
	private float tornadoSpeed;
	private Global globalObj;
	private Vector3 lastVelocity;
	private Vector3 tempPosition;
	private Vector3 differenceVelocity;
	private float lastSteepiness = 0f;
	
	public float life;
	
	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find ("GlobalObject");
		globalObj = g.GetComponent<Global>();
		float theta = Random.Range (-2*Mathf.PI,2*Mathf.PI);
		initialVelocity = new Vector3(Mathf.Cos (theta),0,Mathf.Sin (theta));
		gameObject.rigidbody.velocity = initialVelocity.normalized * maxSpeed;
		lastVelocity = gameObject.rigidbody.velocity;

//		moveable = false;
		life = 5.0f;
	}
	
	void Update()
	{	
		life -= Time.deltaTime;
		if (life <= 0.0f)
		{
			Die ();
		}
	}
		
	void Die()
	{
		Destroy (gameObject);
	}
	
}
