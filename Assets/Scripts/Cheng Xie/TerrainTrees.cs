using UnityEngine;
using System.Collections;

public class TerrainTrees : MonoBehaviour {
	
	public GameObject debrisPreFab;
	public GameObject tornado;
	TerrainData terrain;
	// Use this for initialization
	void Start () {
	terrain = Terrain.activeTerrain.terrainData;
	}
	
	// Update is called once per frame
	void Update () {
		
		ArrayList instances = new ArrayList();
		
		
        float maxDistance = float.MaxValue;
		TreeInstance[] allTrees = terrain.treeInstances;
		
		Vector3 closestTreePosition;
		
		int closestIndex;
		/*for (int i = 0; i < allTrees.Length; i++)
		{
			TreeInstance currentTree = allTrees[i];
			Vector3 worldPosition = Vector3.Scale(currentTree.position, terrain.size) + Terrain.activeTerrain.transform.position;
			
			float distance = Vector3.Distance(currentTreeWorldPosition, tornado.transform.position);
			
			if (distance < maxDistance)
            {

                maxDistance = distance;
                closestIndex = i;
                closestTreePosition = worldPosition;

            }
		}
		*/
		
		
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
			//print(test);
			if ((distance)< 6)
			{
				KillTree(tree, worldPosition);
			}
			else
			{
				instances.Add(tree);
				
			}
			//tree.
		}
		float[,] heights = terrain.GetHeights(0, 0, 0, 0);
		terrain.SetHeights(0, 0, heights);
		terrain.treeInstances = (TreeInstance[])instances.ToArray(typeof(TreeInstance));
		
	
	}
	
	void KillTree(TreeInstance deadObject, Vector3 position)
	{
		if (debrisPreFab)
		{
			Instantiate(debrisPreFab, position, Quaternion.identity);
		}
		
		//Destroy (deadObject);		
	}
}
