using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MDObject : MonoBehaviour
{
    public Transform Player;
    public float distance;
    public GameObject[] spawnCoords;
    void Start()
    {
        Vector3 pos = transform.position;

        /* pos.x = Random.Range(-117f, 33f);
         pos.y = 3;
         pos.z = Random.Range(-84f, 107f);*/
        //Populate spawnCoords with EGOs at 2 corners of the spawn area, NW/SE (-x +z/+x -z)
        var left = spawnCoords[0].transform.position.x;
        var right = spawnCoords[1].transform.position.x;
        var up = spawnCoords[0].transform.position.z;
        var down = spawnCoords[1].transform.position.z;
        print(left + down + up + right);
        pos.x = Random.Range(left,right);
        print(pos.x);
        pos.y = 3;
        pos.z = Random.Range(up,down);
        print(pos.z);
        
        transform.position = pos;

        NavMeshHit hitloc;
        if (NavMesh.SamplePosition(transform.position, out hitloc, 10f, NavMesh.AllAreas))
        {
            pos = hitloc.position;
            transform.position = pos;

        }
        else
        {
            StartCoroutine("Move");
        }
    }
    IEnumerator Move()
    {

        yield return new WaitForSeconds(.1f);
        Vector3 pos = transform.position;

        /* pos.x = Random.Range(-117f, 33f);
         pos.y = 3;
         pos.z = Random.Range(-84f, 107f);*/
        //Populate spawnCoords with 2 corners of the spawn area, NW/SE (-x +z/+x -z)
        var left = spawnCoords[0].transform.position.x;
        var right = spawnCoords[1].transform.position.x;
        var up = spawnCoords[0].transform.position.z;
        var down = spawnCoords[1].transform.position.z;
        pos.x = Random.Range(left, right);
        pos.y = 3;
        pos.z = Random.Range(up, down);
        print(pos.x + pos.z + "Move");
        transform.position = pos;

        NavMeshHit hitloc;
        if (NavMesh.SamplePosition(transform.position, out hitloc, 5f, NavMesh.AllAreas))
        {
            pos = hitloc.position;
            transform.position = pos;

        }
        else
        {
            StartCoroutine("Move");
        }
    }
        public void Update()
    {
       /* distance = Vector3.Distance(transform.position, Player.position);
        offset = (distance / 20f);
        if(ready = true)
        {
            transform.position = new Vector3(transform.position.x, (start - offset), transform.position.z);
        }
         
        //Changed to separate script*/
        //Randomize location of next item
        if (Input.GetKeyDown("e"))
        {
            if (distance < 2)
            {
                StartCoroutine("Move");
            }
            
        }
    }
}
