using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoundRiser : MonoBehaviour
{
    public Transform player;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.localposition;
        distance = Vector3.Distance(transform.position, player.position);
        //basically y = -distance/20
        //work it out tomorrow mornin

        pos.y = -(distance / 20);
        transform.localposition = pos;
    }
}
