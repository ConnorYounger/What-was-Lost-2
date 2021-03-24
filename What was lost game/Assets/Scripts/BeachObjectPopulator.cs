using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachObjectPopulator : MonoBehaviour
{
    private List<GameObject> beachObjects = new List<GameObject>();
    private List<Transform> spawnPoints = new List<Transform>();

    private void Start()
    {
        // Add all child objects to list of spawn points
        foreach (Transform child in transform)
        {
            spawnPoints.Add(child);
        }

        // Create an array of prefabs from the resource directory and then add each to the list of beach objects
        GameObject[] objs = Resources.LoadAll<GameObject>("Beach Groups/");
                
        foreach (GameObject i in objs)
        {
            beachObjects.Add(i);
        }

        SpawnBeachObjects();
    }

    private void SpawnBeachObjects()
    {
        for (int i =0; i < spawnPoints.Count; i++)
        {
            //int spawnNum = Random.Range(0, spawnPoints.Count);
            int objNum = Random.Range(0, beachObjects.Count);

            Instantiate(beachObjects[objNum], spawnPoints[i].position, Quaternion.identity);
            //spawnPoints.RemoveAt(i);
        }
    }
}
