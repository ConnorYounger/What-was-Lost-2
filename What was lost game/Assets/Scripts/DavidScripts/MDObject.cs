using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MDObject : MonoBehaviour
{
    void Start()
    {
        Randomize();
    }
    public void Randomize()
    {
        //Randomize location of next item
        Vector3 pos = transform.position;

        pos.x = Random.Range(0f, 10f);
        pos.y = 3;
        pos.z = Random.Range(0f, 10f);

        transform.position = pos;
    }
}
