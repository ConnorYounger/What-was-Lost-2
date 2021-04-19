﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TriggerTutorial : MonoBehaviour
{
    [Header("Objects from canvas")]
    public GameObject mMessage;
    public TMP_Text tutorialText;
    
    [Header("Text for sign and UI")]
    //[SerializeField]
    private TMP_Text signText;
    [SerializeField]
    private string signMesage;
    [SerializeField]
    private string tutorialMessage;

    private void Start()
    {
        signText = gameObject.GetComponentInChildren<TMP_Text>();
        signText.text = signMesage;
        //mMessage = GameObject.Find("UI_Message");
        //tutorialText = GameObject.Find("MessageText").GetComponent<TMP_Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Triggered");
            mMessage.GetComponent<Image>().enabled = true;
            StartCoroutine(DisplayTutorialMessage());
        }
    }
    IEnumerator DisplayTutorialMessage()
    {
        // Display a Tutorial message
        //mMessage.GetComponent<Image>().enabled = true;
        mMessage.SetActive(true);
        tutorialText.text = tutorialMessage;
        yield return new WaitForSeconds(5);
        //mMessage.GetComponent<Image>().enabled = false;
        mMessage.SetActive(false);
        Destroy(gameObject);
    }

}
