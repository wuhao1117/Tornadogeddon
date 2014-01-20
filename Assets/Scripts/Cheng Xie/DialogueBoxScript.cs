using UnityEngine;
using System.Collections;

public class DialogueBoxScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//GUI.Box(new Rect(125,25,600,100), "");
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}
	
	void OnGUI () {
		
		
		float width = Screen.width;
		float height = Screen.height;
		GUI.Box(new Rect(width/9.0f,height/21.0f,600,100), "");
//		// Make a background box
//		GUI.Box(new Rect(10,10,100,90), "Loader Menu");
//
//		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
//		if(GUI.Button(new Rect(20,40,80,20), "Level 1")) {
//		}
//
//		// Make the second button.
//		if(GUI.Button(new Rect(20,70,80,20), "Level 2")) {
//		}
	}	
}
