using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChildrenAI : MonoBehaviour
{
    public EnemyStats stats;

    private GameObject target;
    private GameObject heldItemPrefab;

    private InventorySlot heldItem;

    public string targetName;
    private string[] states;

    private int currentState;

    public float harassTime = 5;
    public int itemStealChance = 25;
    private float destinationOffset = 2f;
    private float timer;
    private float timeBetweenFootStepSounds = 0.5f;
    private float soundTimer;

    private bool hasItem;

    public Transform itemHoldPoint;

    public InventoryObject targetInventory;

    public Animator animator;

    private TMP_Text annoyingKidItemStolenText;

    public string metalDetectorScriptObject = "Metal_detectin_object";
    private GameObject metalDetectorObject;

    private AudioSource audioSource;

    void Start()
    {
        SetStates();

        target = GameObject.Find(targetName);

        if (GameObject.Find("AnnoyingKidItemStolenText") && GameObject.Find("AnnoyingKidItemStolenText").GetComponent<TMP_Text>())
        {
            annoyingKidItemStolenText = GameObject.Find("AnnoyingKidItemStolenText").GetComponent<TMP_Text>();
        }

        if(audioSource = gameObject.GetComponent<AudioSource>())
        {
            audioSource.clip = stats.triggerSound;
        }

        metalDetectorObject = GameObject.Find(metalDetectorScriptObject);
    }

    private void SetStates()
    {
        states = new string[3] { "Idle", "Engage", "Cooldown" };

        stats.startLocation = transform.position;
        timeBetweenFootStepSounds = stats.timeBetweenFootStepSounds;
    }

    void Update()
    {
        CurrentState();

        if (Input.GetKeyDown(KeyCode.F))
        {
            StopEngageing();
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
        Debug.Log("current state = Idle");
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
            currentState = 1;

        if (audioSource)
        {
            audioSource.Play();
        }
    }

    void Engage()
    {
        Debug.Log("current state = Engauge");

        if (!hasItem)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > destinationOffset)
            {
                // Move towards player
                transform.LookAt(target.transform.position);
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, stats.movementSpeed * Time.deltaTime);

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

                    timer = 0;
                }
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, stats.startLocation) > destinationOffset)
            {
                // Move to starting position
                transform.LookAt(stats.startLocation);
                transform.position = Vector3.MoveTowards(transform.position, stats.startLocation, stats.movementSpeed * Time.deltaTime);

                //Debug.Log("Move towards starting pos");                
            }
            else
            {
                // Look at player
                transform.LookAt(target.transform.position);

                //Debug.Log("Look at player and wait");

                // Play laughing animation ??? + sound ?? maybe playing animation ?
                if (animator)
                {
                    animator.SetBool("isWalking", false);
                }
            }
        }
    }

    private void PlayFootstepSound()
    {
        soundTimer += Time.deltaTime;

        if(soundTimer >= timeBetweenFootStepSounds)
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
            int ranItem = Random.Range(0, targetInventory.Container.Count);

            heldItem = targetInventory.Container[ranItem];

            targetInventory.RemoveItem(ranItem);

            if (heldItem != null)
            {
                Debug.Log("Take Item" + heldItem);

                hasItem = true;

                if (heldItem.item.modelPrefab)
                {
                    heldItemPrefab = Instantiate(heldItem.item.modelPrefab, itemHoldPoint.position, itemHoldPoint.rotation);
                    heldItemPrefab.transform.parent = itemHoldPoint.transform;
                }

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
    }

    void TakePlayerMetalDetector()
    {
        // Check to see if the target has the metal detector script
        if (metalDetectorObject && metalDetectorObject.GetComponent<MetalDetector>() && metalDetectorObject.GetComponent<MetalDetector>().mDetector)
        {
            // Asks the script if the enemy can take the metal detector
            //heldItemPrefab = target.GetComponent<PlayerMetalDetectorItem>().TakeMetalDetector();

            metalDetectorObject.GetComponent<MetalDetector>().mDetector = false;

            if (heldItem != null)
            {
                hasItem = true;

                //heldItemPrefab.transform.parent = itemHoldPoint.transform;
            }
            else
            {
                StopEngageing();
            }
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

            Destroy(heldItemPrefab);

            heldItem = null;
        }
    }

    void GivePlayerMetalDetector()
    {
        if (metalDetectorObject)
        {
            //target.GetComponent<PlayerMetalDetectorItem>().GiveMetalDetector(heldItemPrefab);

            metalDetectorObject.GetComponent<MetalDetector>().mDetector = true;

            heldItemPrefab = null;
        }
    }

    void CoolDown()
    {
        Debug.Log("current state = CoolDown");

        if (Vector3.Distance(transform.position, stats.startLocation) > destinationOffset)
        {
            // Move to starting position
            transform.LookAt(stats.startLocation);
            transform.position = Vector3.MoveTowards(transform.position, stats.startLocation, stats.movementSpeed * Time.deltaTime);
        }
        else
        {
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
}
