using UnityEngine;
using System.Collections;

public class TornadoTimer : MonoBehaviour {

	private Global globalObj;
	private GUIText timerText;
	
	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find ("GlobalObject");
		globalObj = g.GetComponent<Global>();	
		timerText = gameObject.GetComponent<GUIText>();
		timerText.material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		timerText.text = ((int)globalObj.timeLeft).ToString();
	
	}
}
