using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarparkGen : MonoBehaviour
{ 
    public List<Transform> spawns = new List<Transform>();
    public List<GameObject> prefab = new List<GameObject>(); // Lists vs arrays
    
    private int count = 0;
    void Start()
    { // Randomlu picks the number of objects to spawn, runs the spawn script that many times
        int carNum = Random.Range(5, 11);
        for(int i=0; i<carNum; ++i)
        {
            Spawn();
        }
    }

   
    void Spawn()
    {
        int spotNum = Random.Range(0, (11-count));
        int prefabNum = Random.Range(0, 11);

        Instantiate(prefab[prefabNum], spawns[spotNum].position, spawns[spotNum].rotation);
        spawns.RemoveAt(spotNum);
        count = count + 1;
        // Instantiates the random prefab at a random location, removes the spawn from the list to prevent stacking and adds one to the count
        // The count is to keep track of the current size of the list... ah heck there are better ways of doing that
    }
}
