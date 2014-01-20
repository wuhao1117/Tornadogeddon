using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour
{
	
	// Naturally this is very placeholder-y.  Here will probably be inserted a cutscene later.
	
	GUIText storytext;
	private GUIStyle buttonStyle;
	private string story1 = "In the year 20XX, the doomsday criers finally got their wish - the apocalypse began.";
	private string story2 = "The Creator decided that it was time to start the world anew, which meant purging the old world first.";
	private string story3 = "He commanded his Angels to carry out this task through means of their choosing.";
	private string story4 = "You are a tornado spirit with great destructive power.";
	private string story5 = "Today, you are contacted by one of these Angels...";
	private int progress;
	private float timer;
	
	// Use this for initialization

	void Start () {
		progress = 1;
		timer = 0.0f;
		
		storytext = gameObject.GetComponent<GUIText>();
	}

	// Update is called once per frame

	void Update () {
		timer += Time.deltaTime;
	}
	
	void OnGUI (){
		
		// this is the most placeholder-y thing ever but it sort of works for now maybe?
		
		if (progress == 1)
		{
			storytext.text = story1;
			if(GUI.Button(new Rect((Screen.width/2) - 50, (Screen.height/2) + 60, 100, 40), "Next") || Input.GetKeyDown ("space") || timer > 5.0f)
			{ 
				progress = 2;
				timer = 0.0f;
			}
		}
		else if (progress == 2)
		{
			storytext.text = story2;
			if(GUI.Button(new Rect((Screen.width/2) - 50, (Screen.height/2) + 60, 100, 40), "Next") || Input.GetKeyDown("space") || timer > 5.0f ) 
			{ 
				progress = 3;
				timer = 0.0f;
			}
		}
		else if (progress == 3)
		{
			storytext.text = story3;
			if(GUI.Button(new Rect((Screen.width/2) - 50, (Screen.height/2) + 60, 100, 40), "Next") || Input.GetKeyDown("space") || timer > 5.0f ) 
			{ 
				progress = 4;
				timer = 0.0f;
			}
		}
		else if (progress == 4)
		{
			storytext.text = story4;
			if(GUI.Button(new Rect((Screen.width/2) - 50, (Screen.height/2) + 60, 100, 40), "Next") || Input.GetKeyDown("space") || timer > 5.0f ) 
			{ 
				progress = 5;
				timer = 0.0f;
			}
		}
		else if (progress == 5)
		{
			storytext.text = story5;
			if(GUI.Button(new Rect((Screen.width/2) - 50, (Screen.height/2) + 60, 100, 40), "Begin") || Input.GetKeyDown("space") ) 
			{ 
				Application.LoadLevel ("Level1_Tutorial");
			}
		}
	}
}