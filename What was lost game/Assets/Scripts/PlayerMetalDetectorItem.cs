using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMetalDetectorItem : MonoBehaviour
{
    [SerializeField]
    private GameObject metalDetectorPrefab;

    [HideInInspector]
    public GameObject metalDetector;

    public Transform holdPoint;

    public bool canUseMetalDetector = true;

    public List<GameObject> inventory;

    void Start()
    {
        if(metalDetectorPrefab && holdPoint)
        {
            metalDetector = Instantiate(metalDetectorPrefab, holdPoint.position, holdPoint.rotation);

            metalDetector.transform.parent = holdPoint.transform;
        }
        else
        {
            Debug.LogError("Missing metal detector prefab or hold point");
        }
    }

    public void AddItem(GameObject item)
    {
        inventory.Add(item);
    }

    public void GiveMetalDetector(GameObject item)
    {
        metalDetector = item;

        metalDetector.transform.localScale = metalDetectorPrefab.transform.localScale;
        metalDetector.transform.position = holdPoint.transform.position;
        metalDetector.transform.rotation = holdPoint.transform.rotation;
        metalDetector.transform.parent = holdPoint.transform;

        canUseMetalDetector = true;
    }

    public GameObject TakeMetalDetector()
    {
        if (canUseMetalDetector)
        {
            canUseMetalDetector = false;

            return metalDetector;
        }
        else
        {
            return null;
        }
    }

    public GameObject TakeRandomItem()
    {
        if(inventory.Count > 0)
        {
            int randomNumber = Random.Range(0, inventory.Count);

            GameObject randomItem = inventory[randomNumber];

            inventory.Remove(inventory[randomNumber]);

            return randomItem;
        }
        else
        {
            return null;
        }
    }
}
