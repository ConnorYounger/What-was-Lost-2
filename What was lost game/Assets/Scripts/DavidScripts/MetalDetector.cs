using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MetalDetector : MonoBehaviour
{
    public RGenerator rgen;
    //public MDObject obj;
    //Distance detection + indication
    public Transform[] objects;
    private float distance;
    public Image signalStrength;
    //Angle detection + indication
    public GameObject Player;
    public GameObject dirLight;
    public Material On;
    public Material Off;
    //Score counting
    public Text foundAlert;
    private int score = 0;
    //Sound
    public AudioSource mDClick;
    public AudioSource mDTone;
    private float maxFreq = 0.05f;
    float timer;
    //AI
    public bool mDetector;
    void Start()
    {
        //mDTone = GetComponent<AudioSource>(); //why is this here, as i ever?
    }

    
    void Update()
    {
        if (mDetector == true)
        {
            //13/04 rework to accomodate 5 objects:
            Transform[] targets = objects;
            Transform bestTarget = null;
            float closestDistanceSqr = Mathf.Infinity;
            Vector3 currentPosition = transform.position;
            foreach (Transform potentialTarget in targets)
            {
                Vector3 directionToTarget = potentialTarget.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;
                }
            }
            //Spaghetti time
            //distance calculation
            var playerPosition = transform.position;
            playerPosition.y = bestTarget.position.y;
            distance = Vector3.Distance(currentPosition, bestTarget.position);
            signalStrength.fillAmount = (1.0f - (distance / 70));
            //print("distance = " + distance);
            //Angle Calculation
            Vector3 targetDir = bestTarget.position - Player.transform.position;
            float angle = Vector3.Angle(targetDir, Player.transform.forward);
            if (angle < 15.0f)
            {
                dirLight.GetComponent<MeshRenderer>().material = On;
            }
            else
            {
                dirLight.GetComponent<MeshRenderer>().material = Off;
            }



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
            else
            {
                mDTone.volume = 0f;

            }
        }
        if (Input.GetKeyDown("e"))
        {
            if (distance < 2)
            {
                rgen.Collect();
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
            signalStrength.fillAmount = 0f;
        }

    }

    IEnumerator Refresh()
    {
        yield return new WaitForSeconds(3);
        foundAlert.text = "";
    }


}
