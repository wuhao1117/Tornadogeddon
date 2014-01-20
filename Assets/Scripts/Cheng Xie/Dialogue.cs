using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class Dialogue : MonoBehaviour {
	
	public float letterPause;
	public AudioClip sound;
	
	protected StreamReader textReader;
	protected bool reading;
	protected bool eof;
	private bool advanceText;
//	public bool advanceText
//	{
//		get
//		{
//			return advanceText;
//		}
//		
//		set
//		{
//			advanceText = value;
//			if (advanceText == true)
//				Debug.Log("true");
//		}
//	}
	
	private GUITexture guiTextureObj;
	public Texture2D Death;
	public Texture2D Angel;	
	public Texture2D Cthulhu;
	public GameObject Tornado;
	
	public GameObject boxObject;
	private GameObject textBoxObj;
	private bool isAvailTextbox;
	public string Script;
	
	public GUIText nameGUI;
 
	protected string message;
	
	protected string testMessage;
	protected string printMessage;
	
	Vector3 namePosition;
	
	
	private float timer;
	private int index;
	
	private StringReader SR;
	
	private AudioSource s;
 
	// Use this for initialization
	void Start () {
		s = GameObject.Find("GlobalObject").GetComponent<AudioSource>();
		Vector3 textPosition = new Vector3(0.12f,0.92f,0.0f);
		gameObject.transform.position = textPosition;
		SetupDialogue(Script);
//		System.IO.File.WriteAllText(Application.dataPath + "/output.txt", filePath);
		
		//textReader = new StreamReader(Application.dataPath + "/" + "GUI/Level1.txt");
		
		//namePosition = new Vector3(0.01f,0.75f,0);
		

		//advanceText = true;
		
		
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		//Debug.Log(timer);
		if (reading)
		{
	        if (Input.GetKeyDown(KeyCode.Return))
			{			
				EndDialogue();
			}				
	        if (Input.GetKeyDown(KeyCode.Space))
			{			
				GetDialogue();	
			}
			if (message.Length > 0 && message != "<ENDFILE>")
			{
				if (timer > 0.02f)
				ShowText();
			}
			
	
		}
	
	}
	
	public void SetupDialogue(string scriptName)
	{
		if (s && s.isPlaying)
		{
			s.Pause();
		}
		DestroyTextBox();
		Tornado = GameObject.Find ("Tornado");
		TornadoController tCon = Tornado.GetComponent<TornadoController>();
		
		tCon.moveable = false;
		string filePath = Application.dataPath + "/" + "GUI/";
		filePath += scriptName + ".txt";
		gameObject.guiText.fontSize = 18;
		
		textReader = new StreamReader(filePath);

		reading = true;		
		eof = false;
		guiTextureObj = GameObject.Find("DialoguePicObj").GetComponent<GUITexture>();	
		nameGUI = GameObject.Find("NameGUIObj").GetComponent<GUIText>();

		namePosition = guiTextureObj.transform.position + new Vector3(0.05f,-0.01f,0.0f);
		nameGUI.transform.position = namePosition;
		nameGUI.text = "";		
		
		
		guiTextureObj.texture = null;
		letterPause = 0.01f;
		isAvailTextbox = false;
		CreateTextBox();
		
		testMessage = textReader.ReadToEnd();
		SR = new StringReader(testMessage);
			//= testMessage.IndexOf(System.Environment.NewLine);
		message = "";
		GetDialogue();		
	}
	
	void EndDialogue()
	{
		reading = false;
		SR.Close();
		textReader.Close();
		EnableTornado(true);
		DestroyTextBox();		
	}
	
	void GetDialogue()
	{
		guiText.text = "";
//		endPos = testMessage.IndexOf(System.Environment.NewLine,startPos);
		
		message = SR.ReadLine();
		
		//message = testMessage.Substring(startPos,endPos);
		
		if (message == "<Angel>")
		{
			ShowPicture("Angel");
			index = 0;
			//startPos = endPos + 2;
			GetDialogue();
		}
		
		if (message == "<Death>")
		{
			ShowPicture("Death");
			index = 0;
			GetDialogue();
		}
		
		if (message == "<Cthulhu>")
		{
			ShowPicture("Cthulhu");
			index = 0;
			GetDialogue();
		}
		
		if (message == "<?????>")
		{
			ShowPicture("Cthulhu");
			index = 0;
			GetDialogue();
		}		
		
		if ((message == "") || (message == "\t"))
		{
			GetDialogue();
		}
		
		if (message == "<ENDFILE>")
		{
			EndDialogue();
		}
		index = 0;
	}

	public void ShowText()
	{
		if (guiText.text.Length < message.Length)
		{
			if (message[index] == '$')
				guiText.text += '\n';
			else
			guiText.text += message[index];
			index ++;
			//Debug.Log(message[index]);
//				ShowText (start + 1,end + 1);
			timer = 0;
		
					
		}
	}

	public void ShowPicture(string theName)
	{
		if (theName == "Angel")
		{
			guiTextureObj.texture = Angel;
			nameGUI.text = "ANGEL";			
		}
		
		if (theName == "Death")
		{
			guiTextureObj.texture = Death;
			nameGUI.text = "DEATH";		
		//nameGUI.text = "";		
		}
		
		if (theName == "Cthulhu")
		{
			guiTextureObj.texture = Cthulhu;
			nameGUI.text = "CTHULHU";			
		}
		
		if (theName == "?????")
		{
			guiTextureObj.texture = Cthulhu;
			nameGUI.text = "?????";			
		}		
	}
	
	
	void clearText()
	{
		message = "";
		guiText.text = "";
		nameGUI.text = "";
	}

	void CreateTextBox()
	{
		if (!isAvailTextbox)
		{
			textBoxObj = Instantiate(boxObject) as GameObject;
			isAvailTextbox = true;
		}
	}
	
	void DestroyTextBox()
	{
		if (isAvailTextbox)
		{
			Destroy(textBoxObj);
			isAvailTextbox = false;
			clearText();
			guiTextureObj.texture = null;
		}
	}	
	
	void EnableTornado(bool enabled)
	{
		TornadoController tc = Tornado.GetComponent<TornadoController>();
		tc.moveable = enabled;
		
		s = GameObject.Find("GlobalObject").GetComponent<AudioSource>();
        s.Play ();		
		
	}
	
	public void OnGUI()
	{
		Vector3 scale;
		float originalWidth = 1200.0f;
		float originalHeight = 800.0f;
		 
		scale.x = (float)Screen.width/originalWidth;
		scale.y = (float)Screen.height/originalHeight;
		scale.z = 1;
     
    	GUI.matrix = Matrix4x4.TRS(new Vector3(0,0,0), Quaternion.identity, scale);
		
//		Rect test = new Rect(0.0f, 0.0f, Screen.width, Screen.height);
//		GUILayout.BeginArea(test);
		
		
	}

}
