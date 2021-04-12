using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MDObject : MonoBehaviour
{
    public Transform Player;
    private float distance;
    public float start;
    private float offset;
    private bool ready;
    void Start()
    {
        Vector3 pos = transform.position;

        pos.x = Random.Range(-117f, 33f);
        pos.y = 3;
        pos.z = Random.Range(-84f, 107f);

        transform.position = pos;
        NavMeshHit hitloc;
        if (NavMesh.SamplePosition(transform.position, out hitloc, 300f, NavMesh.AllAreas))
        {
            pos = hitloc.position;
            transform.position = pos;

        }
        else
        {
            StartCoroutine("Move");
        }

        start = transform.position.y;
    }
    IEnumerator Move()
    {

        yield return new WaitForSeconds(.1f);
        Vector3 pos = transform.position;

        pos.x = Random.Range(-117f, 33f);
        pos.y = 3;
        pos.z = Random.Range(-84f, 107f);

        transform.position = pos;
        NavMeshHit hitloc;
        if (NavMesh.SamplePosition(transform.position, out hitloc, 300f, NavMesh.AllAreas))
        {
            pos = hitloc.position;
            transform.position = pos;
            ready = true;
        }
        else 
        { 
            StartCoroutine("Move"); 
        }
    
    }
        public void Update()
    {
        distance = Vector3.Distance(transform.position, Player.position);
        offset = (distance / 20f);
        if(ready = true)
        {
            transform.position = new Vector3(transform.position.x, (start - offset), transform.position.z);
        }
        

        //Randomize location of next item
        if (Input.GetKeyDown("e"))
        {
            if (distance < 2)
            {
                ready = false;
                StartCoroutine("Move");
            }
            
        }
    }
}
