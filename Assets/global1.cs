using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UltimateFracturing;

public class global1 : MonoBehaviour {
	public FracturedObject[] allFracturedObject;
	
	private GameObject tornado;

	// Use this for initialization
	void Start () {
		allFracturedObject = GameObject.FindObjectsOfType(typeof(FracturedObject)) as FracturedObject[];
		
		if(GameObject.Find ("Tornado")) 
			tornado = GameObject.Find ("Tornado");
		else 
			print ("Cannot find Tornado!");
		//allFracturedObject = GameObject.FindGameObjectsWithTag("FracturedObject");
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach(FracturedObject FO in allFracturedObject)
		{
			List<FracturedChunk> listRadius = FO.GetDestructibleChunksInRadius(tornado.transform.position, 20.0f, true);	
			foreach(FracturedChunk chunk in listRadius)
			{
				chunk.DetachFromObject(true);	
			}
		}
	}
}
