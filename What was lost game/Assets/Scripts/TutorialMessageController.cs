using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


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
    private GameObject player;
    private GameObject invDisplayController;

    private void Start()
    {
        player = GameObject.Find("Player");
        player.GetComponent<FirstPersonController>().enabled = false;
        invDisplayController = GameObject.Find("InvDisplayController");
        invDisplayController.SetActive(false);

        // Assign UI elements
        mMessage = GameObject.Find("UI_Message");
        mObjective = GameObject.Find("UI_Objective");
        messageText = GameObject.Find("MessageText").GetComponent<TMP_Text>();
        objectiveTitle = GameObject.Find("GoalTitle").GetComponent<TMP_Text>();
        objectiveText = GameObject.Find("GoalText").GetComponent<TMP_Text>();

        // Call objectives display
        StartCoroutine(StartTutorial());
    }


    IEnumerator StartTutorial()
    {
        yield return StartCoroutine(DisplayObjectiveMessage(oGoalTitle, oGoalMessage));
        ClearDisplayMessages();

        yield return StartCoroutine(DisplayObjectiveMessage(oGoalTitle, oFinishMessage));
        ClearDisplayMessages();

        yield return StartCoroutine(DisplayTutorialMessage(tWalk));
        ClearDisplayMessages();

        yield return StartCoroutine(DisplayTutorialMessage(tLook));
        ClearDisplayMessages();

        yield return StartCoroutine(DisplayTutorialMessage(tDig));
        ClearDisplayMessages();

        yield return StartCoroutine(DisplayTutorialMessage(tInteract));
        ClearDisplayMessages();

        yield return StartCoroutine(DisplayTutorialMessage(tInventory));
        ClearDisplayMessages();

        player.GetComponent<FirstPersonController>().enabled = true;
        yield return new WaitForSeconds(2);

        invDisplayController.SetActive(true);
        GameObject.Find("TutorialCanvas").SetActive(false);
    }

    IEnumerator DisplayTutorialMessage(string _text)
    {
        // Display a Tutorial message
        mMessage.GetComponent<Image>().enabled = true;
        messageText.text = _text;
        yield return new WaitForSeconds(5);
    }

    IEnumerator DisplayObjectiveMessage(string _title, string _text)
    {
        // Display a Objective message
        mObjective.GetComponent<Image>().enabled = true;
        objectiveTitle.text = _title;
        objectiveText.text = _text;
        yield return new WaitForSeconds(5);
    }

    public void ClearDisplayMessages()
    {
        mMessage.GetComponent<Image>().enabled = false;
        messageText.text = "";

        mObjective.GetComponent<Image>().enabled = false;
        objectiveTitle.text = "";
        objectiveText.text = "";
    }
}
