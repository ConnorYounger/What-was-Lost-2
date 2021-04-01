﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MetalDetector : MonoBehaviour
{
    public RGenerator other;
    //Distance detection
    public Transform target;
    private float distance;
    public Image signalStrength;
    //Score counting
    public Text foundAlert;
    private int score = 0;
    //Sound
    public AudioSource mDClick;
    public AudioSource mDTone;
    private float maxFreq = 0.05f;
    float timer;

    public bool mDetector;
    void Start()
    {
        mDTone = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (mDetector == true)
        {

            //tracks distance between player and object, triggering a Collect when the player walks over the object
            var currentPosition = transform.position;
            currentPosition.y = target.position.y;
            distance = Vector3.Distance(currentPosition, target.position);
            signalStrength.fillAmount = (1.0f - (distance / 120));
            //print("distance = " + distance); //(print distance from current object to console) //- debug




            //Metal Detector Sound system
            timer += Time.deltaTime / distance;
            if (timer > maxFreq && distance > 2)
            {
                mDClick.PlayOneShot(mDClick.clip, 1);
                timer = 0;
            }
            if (distance < 2)
            {
                mDTone.volume = 1f;

            }

        }
        if (Input.GetKeyDown("e"))
        {
            if (distance < 2)
            {
                other.Collect();
                //Randomize location of next item
                Vector3 pos = transform.position;

                pos.x = Random.Range(-231f, 146f);
                pos.y = 0;
                pos.z = Random.Range(-180f, -80f);

                transform.position = pos;
            }
            else
            {
                foundAlert.text = "There's nothing here...";
                StartCoroutine(Refresh());
            }
        }
        if (mDetector == false)
        {
            mDTone.volume = 0f;
        }
            if (Input.GetKey("b"))
        { 
            mDetector = false;
        }

        else
        {
            mDetector = true;
        }
    }

    IEnumerator Refresh()
    {
        yield return new WaitForSeconds(3);
        foundAlert.text = "";
    }

}
