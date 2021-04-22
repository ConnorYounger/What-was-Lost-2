using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour

{
    
    private float speed = 10f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime);
    }
}

