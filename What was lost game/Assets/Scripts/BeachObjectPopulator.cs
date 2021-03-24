using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachObjectPopulator : MonoBehaviour
{
    public List<GameObject> beachObjects = new List<GameObject>();
    private List<Transform> spawnPoints = new List<Transform>();

    private void Start()
    {
        foreach (Transform child in transform)
        {
            spawnPoints.Add(child);
        }
    }

    private void SpawnBeachObject()
    {

    }
}
