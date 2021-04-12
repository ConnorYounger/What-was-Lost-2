using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MetalDetector : MonoBehaviour
{
    public RGenerator rgen;
    //public MDObject obj;
    //Distance detection
    public Transform[] objects;
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
    //AI
    public bool mDetector;
    void Start()
    {
        //mDTone = GetComponent<AudioSource>();
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
            //Spag time
            
            var playerPosition = transform.position;
            playerPosition.y = bestTarget.position.y;
            distance = Vector3.Distance(currentPosition, bestTarget.position);
            signalStrength.fillAmount = (1.0f - (distance / 70));
            //print("distance = " + distance);


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
                print("in range");
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
