using UnityEngine;
using System.Collections;

public class FavorBar : MonoBehaviour {
	
	public int favor;
	private int maxAngel = 1000;
	private int maxDeath = -1000;    
	private Texture2D AngelFavor;
	private Texture2D DeathFavor;
	private Texture2D NeutrFavor;
	private Texture2D background;
	GUIStyle style;
	GUIStyle backgroundStyle;
	
	public Texture2D AngelPic;
	public Texture2D DeathPic; 
	private GUITexture angelObj;
	private GUITexture deathObj;
	
	private Texture2D favorBar;
	public Texture2D neutBar;
	public Texture2D angelBar;
	public Texture2D deathBar;
	
	// Use this for initialization
	void Start () {
		favor = 0;
		AngelFavor = new Texture2D(1,1);
		AngelFavor.SetPixel (0,0,new Color(0f,0f,1f,0.6f));
		AngelFavor.Apply();
		DeathFavor = new Texture2D(1,1);
		DeathFavor.SetPixel (0,0,new Color(1f,0f,0f,0.6f));
		DeathFavor.Apply();
		NeutrFavor = new Texture2D(1,1);
		NeutrFavor.SetPixel (0,0,new Color(1f,0.92f,0.016f,0.4f));
		NeutrFavor.Apply();
		background = new Texture2D(1,1);
		background.SetPixel (0,0,new Color(0.5f,0.5f,0.5f,0.5f));
		background.Apply();
		
		angelObj = GameObject.Find ("AngelPic").GetComponent<GUITexture>();
		deathObj = GameObject.Find ("DeathPic").GetComponent<GUITexture>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (favor > maxAngel)
			favor = maxAngel;
		if (favor < maxDeath)
			favor = maxDeath;
		
	}
	
	void OnGUI()
	{
		TornadoController c = GameObject.Find ("Tornado").GetComponent<TornadoController>();
        if (c.moveable == true)
		{
			style = new GUIStyle(GUI.skin.box);
			backgroundStyle = new GUIStyle(GUI.skin.box);
			backgroundStyle.normal.background = background;
			if (favor > 100)
				style.normal.background = AngelFavor;
			else if (favor < -100)
				style.normal.background = DeathFavor;
			else
				style.normal.background = NeutrFavor;
	//		GUI.Box (new Rect(Screen.width-60,50,20,Screen.height-100), GUIContent.none, style);
	//		GUI.Box (new Rect(Screen.width-70,-5+Screen.height/2-favor*Screen.height/2500, 40, 10), "");
			
			
			if (favor > 30)
				favorBar = angelBar;
			
			else if (favor < -30)
				favorBar = deathBar;
			
			else favorBar = neutBar;
//			if (favor <= 0)
				GUI.DrawTexture(new Rect(Screen.width-60,Screen.height/2,20,-favor*Screen.height/2500),favorBar);
				//GUI.Box (new Rect(Screen.width-60,Screen.height/2,0,8),"",style);
//			else
//				GUI.Box (new Rect(Screen.width-60,Screen.height/2-favor*Screen.height/2500,0,favor*Screen.height/2500),"",style);
			GUI.Box (new Rect(Screen.width-60,
							  Screen.height/2-1000*Screen.height/2500
							  ,20,
							  2000*Screen.height/2500)
							  ,"",backgroundStyle);

			angelObj.texture = AngelPic;
			deathObj.texture = DeathPic;
		}
		else
		{
			angelObj.texture = null;
			deathObj.texture = null;
		}
		
//		GUI.Box (new Rect(Screen.width/2,Screen.height/2,1,1),"",style);
	}
}
