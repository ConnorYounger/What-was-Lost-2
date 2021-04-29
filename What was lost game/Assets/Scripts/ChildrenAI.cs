using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class ChildrenAI : MonoBehaviour
{
    public EnemyStats stats;

    private GameObject target;
    private GameObject heldItemPrefab;

    public InventorySlot heldItem;

    public string targetName;
    private string[] states;

    private int currentState;

    public float harassTime = 5;
    public int itemStealChance = 25;
    public float destinationOffset = 2f;
    private float timer;
    private float timeBetweenFootStepSounds = 0.5f;
    private float soundTimer;

    private bool hasItem;
    private bool isAtSpawn;
    private bool canRetrieveItem;

    public Transform itemHoldPoint;

    public InventoryObject targetInventory;

    public Animator animator;

    private TMP_Text annoyingKidItemStolenText;
    private Text getBackText;

    public string metalDetectorScriptString = "Metal_detectin_object";
    private GameObject metalDetectorScript;
    private GameObject playerMetalDetectorObject;
    public GameObject dogMetalDetector;


    private AudioSource audioSource;

    private NavMeshAgent navAgent;
    private Vector3 startLocation;

    void Start()
    {
        SetStates();

        target = GameObject.Find(targetName);

        if (GameObject.Find("AnnoyingKidItemStolenText") && GameObject.Find("AnnoyingKidItemStolenText").GetComponent<TMP_Text>())
        {
            annoyingKidItemStolenText = GameObject.Find("AnnoyingKidItemStolenText").GetComponent<TMP_Text>();
        }

        if (audioSource = gameObject.GetComponent<AudioSource>())
        {
            audioSource.clip = stats.triggerSound;
        }

        metalDetectorScript = GameObject.Find(metalDetectorScriptString);

        if (gameObject.GetComponent<NavMeshAgent>())
        {
            navAgent = gameObject.GetComponent<NavMeshAgent>();
            navAgent.speed = stats.movementSpeed;
        }

        if (GameObject.Find("Metal Detector"))
        {
            playerMetalDetectorObject = GameObject.Find("Metal Detector");
        }

        if (GameObject.Find("Foundalert"))
        {
            getBackText = GameObject.Find("Foundalert").GetComponent<Text>();
        }

        /*
        if (GameObject.Find("Dog Metal Detector"))
        {
            dogMetalDetector = GameObject.Find("Dog Metal Detector");
            dogMetalDetector.SetActive(false);
        }
        */
    }

    private void SetStates()
    {
        states = new string[3] { "Idle", "Engage", "Cooldown" };

        startLocation = transform.position;
        timeBetweenFootStepSounds = stats.timeBetweenFootStepSounds;
    }

    void Update()
    {
        CurrentState();

        if (target && Vector3.Distance(gameObject.transform.position, target.transform.position) < destinationOffset && hasItem && isAtSpawn)
        {
            if (getBackText)
            {
                getBackText.text = stats.itemReturnMessage;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                StopEngageing();
            }

            canRetrieveItem = true;
        }
        else if (getBackText && canRetrieveItem)
        {
            getBackText.text = "";

            canRetrieveItem = false;
        }
    }

    private void CurrentState()
    {
        if (currentState == 0)
        {
            Idle();
        }
        else if (currentState == 1)
        {
            Engage();
        }
        else if (currentState == 2)
        {
            CoolDown();
        }
    }

    void Idle()
    {
        //Debug.Log("current state = Idle");
        // Play Idle Animation

        if (target)
        {
            if (Vector3.Distance(target.transform.position, transform.position) < stats.triggerDistance && currentState == 0)
            {
                Trigger();
            }
        }
    }

    public void Trigger()
    {
        if (currentState == 0)
        {
            currentState = 1;

            PlayTriggerSound();
        }
    }

    void PlayTriggerSound()
    {
        if (currentState == 1 && audioSource)
        {
            //audioSource.clip = stats.triggerSound;
            //audioSource.Play();

            PlaySound(stats.triggerSound);

            //Invoke("PlayTriggerSound", 3);
        }
    }

    void Engage()
    {
        //Debug.Log("current state = Engauge");

        if (!hasItem)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > destinationOffset)
            {
                // Move towards player
                //transform.LookAt(target.transform.position);
                //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, stats.movementSpeed * Time.deltaTime);
                navAgent.SetDestination(target.transform.position);

                //Debug.Log("Move towards player");
                //Debug.Log("Distance = " + Vector3.Distance(transform.position, target.transform.position) + " / " + destinationOffset);

                // Play running animation
                if (animator)
                {
                    animator.SetBool("isWalking", true);
                }

                if (stats.footStepSound)
                {
                    PlayFootstepSound();
                }
            }
            else
            {
                // Play running animation
                if (animator)
                {
                    animator.SetBool("isWalking", false);
                }

                if (timer < harassTime)
                {
                    timer += Time.deltaTime;

                    //Debug.Log("Timer = " + timer);
                }
                else
                {
                    int random = Random.Range(0, 100);

                    //Debug.Log("Random steal chance = " + random);

                    if (random <= itemStealChance)
                    {
                        IntteractWithPlayer();
                    }
                    else
                    {
                        StopEngageing();
                    }

                    timer = 0;
                }
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, startLocation) > destinationOffset)
            {
                // Move to starting position
                //transform.LookAt(stats.startLocation);
                //transform.position = Vector3.MoveTowards(transform.position, stats.startLocation, stats.movementSpeed * Time.deltaTime);
                navAgent.SetDestination(startLocation);

                animator.SetBool("isWalking", true);

                isAtSpawn = false;

                //Debug.Log("Move towards starting pos");                
            }
            else
            {
                // Look at player
                //transform.LookAt(target.transform.position);

                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * stats.movementSpeed);

                //Debug.Log("Look at player and wait");

                // Play laughing animation ??? + sound ?? maybe playing animation ?
                if (animator)
                {
                    animator.SetBool("isWalking", false);
                }

                isAtSpawn = true;
            }
        }
    }

    private void PlayFootstepSound()
    {
        soundTimer += Time.deltaTime;

        if (soundTimer >= timeBetweenFootStepSounds)
        {
            soundTimer = 0;
            AudioSource.PlayClipAtPoint(stats.footStepSound, transform.position);
        }
    }

    public void IntteractWithPlayer()
    {
        if (stats.enemyType == EnemyStats.EnemyType.Child)
        {
            TakePlayerItem();
        }
        else if (stats.enemyType == EnemyStats.EnemyType.Dog)
        {
            TakePlayerMetalDetector();
        }
    }

    void TakePlayerItem()
    {
        // Check to see if the target has the inventory script
        if (targetInventory && targetInventory.Container.Count > 0)
        {
            if (audioSource && stats.sucessSound)
            {
                //audioSource.clip = stats.sucessSound;
                //audioSource.Play();

                PlaySound(stats.sucessSound);
            }

            int ranItem = Random.Range(0, targetInventory.Container.Count);

            heldItem = targetInventory.Container[ranItem];

            targetInventory.RemoveItem(ranItem);

            if (heldItem != null)
            {
                Debug.Log("Take Item" + heldItem);

                hasItem = true;

                /*
                if (heldItem.item.modelPrefab)
                {
                    heldItemPrefab = Instantiate(heldItem.item.modelPrefab, itemHoldPoint.position, itemHoldPoint.rotation);
                    heldItemPrefab.transform.parent = itemHoldPoint.transform;
                }
                */

                if (annoyingKidItemStolenText)
                {
                    annoyingKidItemStolenText.enabled = true;
                    annoyingKidItemStolenText.text = "An annoying kid stole " + heldItem.item.itemName + "!";
                }
            }
            else
            {
                StopEngageing();
            }
        }
        else
        {
            StopEngageing();
        }
    }

    void TakePlayerMetalDetector()
    {
        // Check to see if the target has the metal detector script
        if (target && metalDetectorScript.GetComponent<MetalDetector>())
        {
            if (metalDetectorScript.GetComponent<MetalDetector>().mDetector == true)
            {
                if (audioSource && stats.sucessSound)
                {
                    //audioSource.clip = stats.sucessSound;
                    //audioSource.Play();

                    PlaySound(stats.sucessSound);
                }

                hasItem = true;

                metalDetectorScript.GetComponent<MetalDetector>().mDetector = false;

                playerMetalDetectorObject.SetActive(false);
                dogMetalDetector.SetActive(true);
            }
            else
            {
                StopEngageing();
            }
        }
        else
        {
            StopEngageing();
        }
    }

    public void StopEngageing()
    {
        Debug.Log("Stop Engaging");

        if (hasItem)
        {
            ReturnItem();
        }

        currentState = 2;

        hasItem = false;
        timer = 0;
    }

    void ReturnItem()
    {
        if(audioSource && stats.disapointedSound)
        {
            //audioSource.clip = stats.disapointedSound;
            //audioSource.Play();

            PlaySound(stats.disapointedSound);
        }

        if (stats.enemyType == EnemyStats.EnemyType.Child)
        {
            GivePlayerItem();
        }
        else if (stats.enemyType == EnemyStats.EnemyType.Dog)
        {
            GivePlayerMetalDetector();
        }
    }

    void GivePlayerItem()
    {
        if (targetInventory)
        {
            if (annoyingKidItemStolenText)
            {
                annoyingKidItemStolenText.enabled = false;
            }

            targetInventory.AddItem(heldItem.item);

            //Destroy(heldItemPrefab);

            heldItem = null;
        }
    }

    void GivePlayerMetalDetector()
    {
        if (metalDetectorScript)
        {
            metalDetectorScript.GetComponent<MetalDetector>().mDetector = true;

            playerMetalDetectorObject.SetActive(true);
            dogMetalDetector.SetActive(false);

            heldItemPrefab = null;
        }
    }

    void CoolDown()
    {
        Debug.Log("current state = CoolDown");

        if (Vector3.Distance(transform.position, startLocation) > destinationOffset)
        {
            // Move to starting position
            navAgent.SetDestination(startLocation);

            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);

            // Start cool down timer
            if (timer < stats.coolDownTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                currentState = 0;
                timer = 0;
            }
        }
    }

    // Custom sound EGO
    void PlaySound(AudioClip clip)
    {
        GameObject sound = new GameObject();
        sound.transform.parent = gameObject.transform;
        AudioSource soundA = sound.AddComponent<AudioSource>();
        soundA.clip = clip;
        soundA.Play();
        Destroy(sound, clip.length);
    }
}
