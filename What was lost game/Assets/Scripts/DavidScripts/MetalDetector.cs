using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MetalDetector : MonoBehaviour
{
    //Distance detection
    public Transform target;
    private float distance;
    public Image signalStrength;
    //Score counting
    public Text scoreDist;
    public Text foundAlert;
    private int score = 0;
    private int randomRare;
    //Sound
    public AudioSource mDClick;
    public AudioSource mDTone;
    private float maxFreq = 0.05f;
    float timer;
    float toneTimer;
    private bool inRange = false;
    void Start()
    {
        mDTone = GetComponent<AudioSource>();
    }
    void Update()
    {
        //tracks distance between player and object, triggering a Collect when the player walks over the object
        var currentPosition = transform.position;
        currentPosition.y = target.position.y;
        distance = Vector3.Distance(currentPosition, target.position);
        signalStrength.fillAmount = (1.0f - (distance / 120));
        //print("distance = " + distance); //(print distance from current object to console) //- debug
        scoreDist.text = score.ToString();
        if (Input.GetKeyDown("e"))
        {
            if (distance < 2)
            {
                Collect();
            }
            else
            {
                foundAlert.text = "There's nothing here...";
                Invoke("reset", 2);
            }
        }

        //Metal Detector Sound system
        timer += Time.deltaTime / distance;
        toneTimer += Time.deltaTime;
        print(toneTimer);
        if (timer > maxFreq && distance > 2)
        {
            mDClick.PlayOneShot(mDClick.clip, 1);
            timer = 0;
        }
        if (distance < 2)
        {
            mDTone.volume = 1f;

        }
        if (distance > 2 )
        {
            mDTone.volume = 0f;

        }

    }

    void Collect() // Runs when an object is walked over
    {
        //++score;
        //Randomly decide rarity of found item: Rare: 0-10 10% Uncommon 11-40 30% Common 41-100 60%
        randomRare = (Random.Range(0, 100));
        if (randomRare < 10)
        {
            valuableItem();
        }
        else if (randomRare > 41)
        {
            commonItem();
        }
        else
        {
            uncommonItem();
        }

        //Randomize location of next item
        Vector3 pos = transform.position;

        pos.x = Random.Range(-231f, 146f);
        pos.y = 0;
        pos.z = Random.Range(-180f, -80f);

        transform.position = pos;

       // RaycastHit hit;
       // Vector3 groundLocation;
       // Debug.DrawLine(Vector3.zero, Vector3.up * 100);
      //  if (Physics.Raycast(transform.position, Vector3.up, out hit, Mathf.Infinity))
      //  {
       //     groundLocation = hit.point;
       //     print(hit.collider.name);
       //     transform.position = groundLocation;

       // }
        
    }

    //Add different score amounts depending on rarity of found object and Alert player to rarity of found object
    void valuableItem()
    {
        score = score + 10;
        print("Rare Item Found!");
        foundAlert.text = "Rare Item Found!";
        Invoke("reset", 2);
    }
    void commonItem()
    {
        score = score + 1;
        print("Common Item Found!");
        foundAlert.text = "Common Item Found!";
        Invoke("reset", 2);
    }
    void uncommonItem()
    {
        score = score + 5;
        print("Uncommon Item Found!");
        foundAlert.text = "Uncommon Item Found!";
        Invoke("reset", 2);
    }
    void reset() // Clear the alert from the screen
    {
        foundAlert.text = "";
    }
 
}
