using UnityEngine;
using System.Collections;

public class CreditsScript : MonoBehaviour {
	
	GUIText credits;
	private GUIStyle buttonStyle;
	private string creditText = "Initial Concept:\n" + 
								"Hao Wu\n\n" +
			
								"Story and Character Design:\n" + 
								"Cheng Xie\n\n" +
			
								"Programming:\n" +
								"Katherine Anderson\nHao Wu\nCheng Xie\n\n" +
			
								"Particle Effects:\n" +
								"Katherine Anderson\n" +
								"Hao Wu\n" +
								"Cheng Xie\n\n" +
			
								"Artistic Direction:\n" +
								"Cheng Xie\n" +
								"Royalty free assets from the Internet\n\n" +
			
								"Physics Direction:\n" + 
								"Hao Wu\n\n" +
								
								"Level Design:\n" +
								"Katherine Anderson\nHao Wu\nCheng Xie\n\n" +
			
								"Sound Direction:\n" +
								"Katherine Anderson\n" +
								"Sound Effects from freesound.org\n\n" +
			
								"Music Selection:\n" +	
								"'Spring' from The Four Seasons, Vivaldi\n'Ride of the Valkyries', Wagner\n" + 
								"'Requiem Mass - Dies Irae', Verdi\n'Mars' from the Planets Suite, Holst\n" + 
								"'Yakety Sax', Boots Randolph"
			;

//								"Created By:\nKatherine Anderson\nHao Wu\nCheng Xie\n\n"
//		+ "Sound Effects from freesound.org\n\n"
//			+ "Music:\n'Spring' from The Four Seasons, Vivaldi\n'Ride of the Valkyries', Wagner\n"
//			+ "'Requiem Mass - Dies Irae', Verdi\n'Mars' from the Planets Suite, Holst\n"
//			+ "'Yakety Sax', Boots Randolph";
	float off;
	
	// Use this for initialization
	void Start () {
		credits = gameObject.GetComponent<GUIText>();
		//credits.text = creditText;
		credits.text="";
		off = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		off += Time.deltaTime * 75;
	}
	
	void OnGUI() {
		GUI.Box(new Rect((Screen.width/2) - 180, 600 - off, 360, 700), creditText);
		//(Screen.height/2) - 120
		if(GUI.Button(new Rect((Screen.width/2) - 50, (Screen.height) - 100, 100, 40), "Menu")) 
			{ 
				Application.LoadLevel ("Title Screen");
			}
	}
}

