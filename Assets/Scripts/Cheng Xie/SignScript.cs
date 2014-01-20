using UnityEngine;
using System.Collections;

public class SignScript : MonoBehaviour {

	// Use this for initialization
	public GameObject dialogue;
	private GameObject tornado;
	Dialogue dLog;
	void Start () {
		if(GameObject.Find ("Tornado")) 
			tornado = GameObject.Find ("Tornado");
		dialogue = GameObject.Find ("DialogueObj");
		dLog = dialogue.GetComponent<Dialogue>();
		ParticleColor pc = tornado.GetComponent<ParticleColor>();
		pc.sharknado = true;
		tornado.rigidbody.velocity *= 0.0f;
		dLog.SetupDialogue("BonusSign");
		
		
	}
}
