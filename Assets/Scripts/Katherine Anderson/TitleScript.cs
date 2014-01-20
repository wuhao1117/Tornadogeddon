using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour {

	private GUIStyle buttonStyle;
	//private bool instructions = false;
	//private string story = "This is a string of words that will make up the background.\n"
	//	+ "It's kind of placeholdery for now though.\n\n"
	//	+ "Use the Arrow Keys or WASD to move.";

	// Use this for initialization

	void Start () {

	}

	// Update is called once per frame

	void Update () {

	}
	
	void OnGUI (){

		//if (instructions)
		//{
		//	GUI.Box(new Rect((Screen.width/4), (Screen.height/4), Screen.width/2, Screen.height/2), story); 
		//	if(GUI.Button(new Rect((Screen.width/2) - 50, (Screen.height/2) + 40, 100, 40), "Begin")) 
		//	{ 
		//		Application.LoadLevel(1);
		//	}
		//}
		//else
		//{
		GUILayout.BeginArea(new Rect(Screen.width / 2, 3*Screen.height / 4, (Screen.width/2) -10, 200));
		// Load the main scene

		// The scene needs to be added into build setting to be loaded!

		if (GUILayout.Button("Start"))
		{
			Application.LoadLevel(1);
			//instructions = true;
		}
		
		//if (GUILayout.Button ("High Scores"))
		//{
		//	
		//}

		if (GUILayout.Button ("Credits"))
		{
			Application.LoadLevel("Credits Scene");
			
		}
		
		if (GUILayout.Button("Exit"))
		{
			Application.Quit();
			Debug.Log ("Application.Quit() only works in build, not in editor");
		}

		GUILayout.EndArea();
		//}
	}
}