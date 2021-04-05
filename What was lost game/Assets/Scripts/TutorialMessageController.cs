using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialMessageController : MonoBehaviour
{
    [HideInInspector]
    public string tWalk = "use 'w,a,s,d' to walk \n hold 'shift' to run";
    [HideInInspector]
    public string tLook;
    [HideInInspector]
    public string tDig;
    [HideInInspector]
    public string tInteract;
    [HideInInspector]
    public string tInventory;


    private TMP_Text messageText;

    private void Start()
    {
        messageText = GameObject.Find("UI_Message").GetComponentInChildren<TMP_Text>();

        messageText.text = tWalk;
    }
}
