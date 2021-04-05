﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMessageController : MonoBehaviour
{
    [Header("Tutorial Messages")]
    public string tWalk = "use 'w,a,s,d' to walk \n hold 'shift' to run";
    public string tLook = "use mouse to \n look around";
    public string tDig = "press 'e' to dig \n up an item";
    public string tInteract = "press 'f' \n to interact";
    public string tInventory = "press 'i' \n to view inventory";

    [Header("Objective Messages")]
    public string oGoalTitle = "today's goal";
    public string oGoalMessage = "use detector to search \n for lost items";
    public string oFinishMessage = "the day will end at sundown \n or if you find all the items";

    private GameObject mMessage, mObjective;
    private TMP_Text messageText, objectiveTitle, objectiveText;

    private void Start()
    {
        mMessage = GameObject.Find("UI_Message");
        mObjective = GameObject.Find("UI_Objective");
        messageText = GameObject.Find("MessageText").GetComponent<TMP_Text>();
        objectiveTitle = GameObject.Find("GoalTitle").GetComponent<TMP_Text>();
        objectiveText = GameObject.Find("GoalText").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            DisplayTutorialMessage(tWalk);
        } else if (Input.GetKeyDown("2"))
        {
            DisplayTutorialMessage(tLook);
        }
        else if (Input.GetKeyDown("3"))
        {
            DisplayTutorialMessage(tDig);
        }
        else if (Input.GetKeyDown("4"))
        {
            DisplayObjectiveMessage(oGoalTitle, oGoalMessage);
        }
        else if (Input.GetKeyDown("5"))
        {
            DisplayObjectiveMessage(oGoalTitle, oFinishMessage);
        }
    }

    public void DisplayTutorialMessage(string _text)
    {
        if (!mMessage.GetComponent<Image>().enabled)
        {
            mMessage.GetComponent<Image>().enabled = true;
            messageText.text = _text;
        }
        else if (mMessage.GetComponent<Image>().enabled)
        {
            mMessage.GetComponent<Image>().enabled = false;
            messageText.text = "";
        }
    }

    public void DisplayObjectiveMessage(string _title, string _text)
    {
        if (!mObjective.GetComponent<Image>().enabled)
        {
            mObjective.GetComponent<Image>().enabled = true;
            objectiveTitle.text = _title;
            objectiveText.text = _text;
        }
        else if (mObjective.GetComponent<Image>().enabled)
        {
            mObjective.GetComponent<Image>().enabled = false;
            objectiveTitle.text = "";
            objectiveText.text = "";
        }
    }
}
