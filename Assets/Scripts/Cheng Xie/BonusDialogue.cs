using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class OpenDialogue : Dialogue {

	// Use this for initialization
	public Texture2D Cthulhu;	
	void Start () {
		textReader = new StreamReader(Application.dataPath + "/" + "GUI/Intro.txt");
		ReadFile();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void ReadFile()
	{
		while (reading)
		{
			while(!textReader.EndOfStream)
			{
				message = textReader.ReadLine();
				
				if (message.StartsWith("<BREAK>"))
				{
					//Debug.Log("IN HERE");
					
					reading = false;
					break;
				}
				
				if (message.StartsWith("<ENDFILE>"))
				{
					//Debug.Log("IN HERE");
					eof = true;
					reading = false;
					textReader.Close();					
					break;
				}
				
				else
				{					
//					showLabel();
				}
			}
		}		
	}
}
