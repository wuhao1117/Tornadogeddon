using UnityEngine;
using System.Collections;
using System.IO;

public class TerrainTrees : MonoBehaviour {
	
	public GameObject debrisPreFab;
	public GameObject tornado;
	TerrainData terrain;
	TreeInstance[] origTrees;
	
	// Use this for initialization
	void Start () 
	{
		terrain = Terrain.activeTerrain.terrainData;
		
		origTrees = terrain.treeInstances;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		ArrayList instances = new ArrayList();
				
		foreach (TreeInstance tree in terrain.treeInstances)
		{
			Vector3 worldPosition = Vector3.Scale(tree.position, terrain.size) + Terrain.activeTerrain.transform.position;
			float treeFloat = Vector3.Distance(worldPosition, transform.position);
			//print (distance);
			//print ("tree position: " + tree.position);
			//print ("tornado position: " + tornado.transform.position.magnitude);
			//Vector3 length = tree.position - tornado.transform.position;
			//print(length.magnitude);
			float distance = treeFloat -  tornado.transform.position.magnitude;
			if ((distance)< 6)
			{
				KillTree(tree, worldPosition);
			}
			else
			{
				instances.Add(tree);
				
			}
		}
		terrain.treeInstances = (TreeInstance[])instances.ToArray(typeof(TreeInstance));
		float[,] heights = terrain.GetHeights(0, 0, 0, 0);
		terrain.SetHeights(0, 0, heights);
		
	
	}
	
	void KillTree(TreeInstance deadObject, Vector3 position)
	{
		if (debrisPreFab)
		{
			Instantiate(debrisPreFab, position, Quaternion.identity);
		}
	}
	
	void OnApplicationQuit() 
	{
		terrain.treeInstances = origTrees;
	}
}
