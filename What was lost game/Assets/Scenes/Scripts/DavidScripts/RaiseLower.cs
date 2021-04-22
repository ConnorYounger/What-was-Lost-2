using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseLower : MonoBehaviour
{

    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            transform.localPosition = (new Vector3(0.077f, 1.195f, 0.75f));
            //transform.position.x = 0.077; //(center screen)
            //transform.position.y = 1.145;
        }
        else
        {
           
            transform.localPosition = (new Vector3(0.3f, 1.145f, 0.7f));
            //transform.position.x = 0.077; //off to side
            //transform.position.y = 1.195;
        }
    }
}
