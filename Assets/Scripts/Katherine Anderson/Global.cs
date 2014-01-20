using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

//	public Transform target;
	public string nextLevelName;
	public int score;
	public float currentHealth = 100.0f;
	public int multiplier = 1;
	public int objectCount;	
	public int bronzeScore;
	public int silverScore;
	public int goldScore;
	public bool activateTimer = true;
	public float timeLimit;
	public int debrisLimit;
	public Transform tornado;
	[HideInInspector]
	public float timeLeft;
	[HideInInspector]
	public Queue debrisQueue;
	[HideInInspector]
	public bool arrived = false;
	
	private float maxHealth = 100.0f;	
	private float healthBarLength;
	private bool endgame = false;
	private int leveltoload;
	private int restart;	
	private Vector3 wantedPos;	
	private Texture2D HPHigh;
	private Texture2D HPMid;
	private Texture2D HPLow;
	private Texture2D regStyle;
	private GUIStyle HPbar;
	
	
	void Awake()
	{
		debrisQueue = new Queue();
	}
	// Use this for initialization
	void Start () {
		
		score = 0;
		healthBarLength = Screen.width / 3;
		leveltoload = Application.loadedLevel + 1;
		restart = Application.loadedLevel;
		regStyle = new Texture2D(1,1);
		regStyle.SetPixel (0,0,new Color(.1f,.1f,.1f,0.5f));
		regStyle.Apply();
		HPHigh = new Texture2D(1,1);
		HPHigh.SetPixel(0,0,new Color(0f,.5f,0f,0.6f));
		HPHigh.Apply ();
		HPMid = new Texture2D(1,1);
		HPMid.SetPixel(0,0,new Color(.5f,.46f,.008f,0.6f));
		HPMid.Apply ();
		HPLow = new Texture2D(1,1);
		HPLow.SetPixel(0,0,new Color(.5f,0f,0f,0.6f));
		HPLow.Apply ();
		
		objectCount = destructibleObjectCount ();
		Physics.IgnoreLayerCollision(8, 8, true);
		Physics.IgnoreLayerCollision(9, 10, true);
		
		timeLeft = timeLimit;
	}
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown ("y"))
		{
			endgame = true;	
		}
		
//		if(debrisQueue.Count > debrisLimit) 
//		{
//			GameObject debrisToDestroy = debrisQueue.Dequeue() as GameObject;
//			Destroy(debrisToDestroy);
//		}
//		
//		wantedPos = Camera.main.WorldToScreenPoint(target.position);
//		wantedPos.y = Screen.height - (wantedPos.y + 1f);
		
		objectCount = destructibleObjectCount();
//		if (objectCount == 0)
//			endgame = true;
	}
	
	void FixedUpdate(){
		if(debrisQueue.Count > debrisLimit) 
		{
			GameObject debrisToDestroy = debrisQueue.Dequeue() as GameObject;
			Destroy(debrisToDestroy);
		}
	}
	
	void OnGUI()
	{
		GUI.skin.box.normal.background = regStyle;
		
//		HPbar = new GUIStyle(GUI.skin.box);
//		if (currentHealth/maxHealth >= 0.5f)
//			HPbar.normal.background = HPHigh;
//		else if (currentHealth/maxHealth >= 0.25f)
//			HPbar.normal.background = HPMid;
//		else
//			HPbar.normal.background = HPLow;
		
		if (endgame)
		{
			TornadoController c = GameObject.Find ("Tornado").GetComponent<TornadoController>();
            c.maxSpeed = 0f;
            GameObject g = GameObject.Find ("Tornado");
            g.rigidbody.velocity = g.rigidbody.velocity * 0;
            multiplier = 0; // can't earn any more points once the level is done	
			c.moveable = false;
			
			string endPhrase;
			if(arrived)
			{
				if (score >= goldScore)
					endPhrase = "Level Complete!\nExcellent work!\nGold medal for you!";
				else if (score >= silverScore)
					endPhrase = "Level Complete!\nGood job.\nSilver medal for you!";
				else if (score >= bronzeScore)
					endPhrase = "Level Complete!\nI suppose you tried.\nBronze medal for you.";
				else
					endPhrase = "That was terrible.\nGo back and try again.";
			}
			
			else endPhrase = "You failed to get to your destination in time\nGo back and try again.";
			GUI.Box(new Rect((Screen.width/2) - 150, (Screen.height/2) - 60, 300, 60), endPhrase); 
			
			if (score >= bronzeScore && arrived)
			{
				if(GUI.Button(new Rect((Screen.width/2) - 50, (Screen.height/2) + 2, 100, 40), "Next Level")) 
				{ 
					if (nextLevelName != "")
						Application.LoadLevel(nextLevelName);
					else
						Application.LoadLevel(leveltoload);
				}
			}
			else
			{
				if(GUI.Button(new Rect((Screen.width/2) - 50, (Screen.height/2) + 2, 100, 40), "Restart")) 
				{ 
					Application.LoadLevel(restart);
				}	
			}
		}
		else
		{
			//GUI.Box (new Rect(wantedPos.x, wantedPos.y, 200, 20), currentHealth + "/" + maxHealth);
//			GUI.Box (new Rect(wantedPos.x,wantedPos.y,200,20), (int) currentHealth + "/" + maxHealth);
//			GUI.Box (new Rect(wantedPos.x+1,wantedPos.y+1,198*currentHealth/maxHealth,18),"",HPbar);
		}
	}
	
//	public void adjustCurrentHealth(float adj)
//	{
//		currentHealth += adj;
//		if (currentHealth < 0.0f)
//			currentHealth = 0.0f;
//		if (currentHealth > maxHealth)
//			currentHealth = maxHealth;
//		healthBarLength = (Screen.width/3) * (currentHealth / maxHealth);
//		if(currentHealth <= 0.0f)
//			endgame = true;
//	}
	
	int destructibleObjectCount()
	{
		GameObject[] array;
		array = GameObject.FindGameObjectsWithTag("Object");
		return array.Length;
	}
	
	public void end()
	{
		endgame = true;	
	}
}
