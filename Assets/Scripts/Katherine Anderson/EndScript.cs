using UnityEngine;
using System.Collections;

public class EndScript : MonoBehaviour
{
	private GUIStyle buttonStyle;

	// Use this for initialization

	void Start () {

	}

	// Update is called once per frame

	void Update () {

	}
	
	void OnGUI (){

		GUILayout.BeginArea(new Rect(Screen.width / 2, 7*Screen.height / 8, (Screen.width/2) -10, 200));
		// Load the main scene

		// The scene needs to be added into build setting to be loaded!

		if (GUILayout.Button("Menu"))
		{
			Application.LoadLevel("Title Screen");
		}

		GUILayout.EndArea();
	}
}