using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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


    private TMP_Text messageText;

    private void Start()
    {
        messageText = GameObject.Find("UI_Message").GetComponentInChildren<TMP_Text>();

        messageText.text = tWalk;
    }
}
