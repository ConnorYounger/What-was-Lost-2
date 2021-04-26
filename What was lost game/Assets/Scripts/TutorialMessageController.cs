using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class TutorialMessageController : MonoBehaviour
{
    [Header("Objective Messages")]
    public string oGoalTitle = "today's goal";
    public string oGoalMessage = "use detector to search \n for lost items";
    public string oFinishMessage = "the day will end at sundown \n or if you find all the items";

    private GameObject mObjective;
    private TMP_Text objectiveTitle, objectiveText;
    private GameObject player;
    public GameObject invDisplayController;
    public GameObject pauseCanvas;

    private void Start()
    {
        player = GameObject.Find("Player");
        player.GetComponent<FirstPersonController>().enabled = false;
        //invDisplayController = GameObject.Find("InvDisplayController");
        invDisplayController.SetActive(false);

        // Assign UI elements
        mObjective = GameObject.Find("UI_Objective");
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

        player.GetComponent<FirstPersonController>().enabled = true;
        yield return new WaitForSeconds(2);

        invDisplayController.SetActive(true);
        pauseCanvas.SetActive(true);
    }

    IEnumerator DisplayObjectiveMessage(string _title, string _text)
    {
        mObjective.GetComponent<Image>().enabled = true;
        objectiveTitle.text = _title;
        objectiveText.text = _text;
        yield return new WaitForSeconds(5);
    }

    public void ClearDisplayMessages()
    {
        mObjective.GetComponent<Image>().enabled = false;
        objectiveTitle.text = "";
        objectiveText.text = "";
    }
}
