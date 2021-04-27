using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RGenerator : MonoBehaviour
{
    private int randomRare;
    public InventoryObject inventory;
    public ItemObject item;
    public ItemObject storyItem; // one storyitem per level - initialise
    public List<ItemObject> junkItems = new List<ItemObject>();
    public List<ItemObject> valueItems = new List<ItemObject>();
    private int sCount, jCount, vCount;
    public Text foundAlert;
    public Image itemPreview;
    public bool key;
    public int nextLevel;
    void Start()
    {
        ItemObject[] objs2 = Resources.LoadAll<ItemObject>("Inventory/TrashItems/");

        foreach (ItemObject i in objs2)
        {
            junkItems.Add(i);
        }
        ItemObject[] objs3 = Resources.LoadAll<ItemObject>("Inventory/ValueItems/");

        foreach (ItemObject i in objs3)
        {
            valueItems.Add(i);
        }

        print(junkItems.Count);
        print(valueItems.Count);
        jCount = junkItems.Count;
        vCount = valueItems.Count;
        //Populate each list with their relevant items and assigns the list size to a middle-man variable - Jank? yes. Unity moment
    }
    public void Collect() // Runs when an object is walked over
    {
        //Randomly decide rarity of found item: Rare: 0-10 10% Uncommon 11-40 30% Common 41-100 60%
        randomRare = (Random.Range(0, 100));
        if (randomRare < 5)
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
        // Temporarily commented for testing  



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
        /*randomRare = (Random.Range(0, sCount));
        print(randomRare);*/
        var item = storyItem;
        if (key)
        {
            inventory.AddItem(item);
            foundAlert.text = "Found: " + item.name +": New Photo Unlocked";
            itemPreview.sprite = item.itemImage;
            var tempColor = itemPreview.color;
            tempColor.a = 1f;
            itemPreview.color = tempColor;
            StartCoroutine(Refresh());
            ProgressCheck();
            key = false;
        }
        else
        {
            Collect();
        }

    }
    void ProgressCheck()
    {
        int current;
        current = PlayerPrefs.GetInt("LevelUnlocked", 0);
        if (current < nextLevel)
        {
            PlayerPrefs.SetInt("LevelUnlocked", nextLevel);
        }
    }
    void commonItem()
    {
        randomRare = (Random.Range(0, jCount));
        print(randomRare);
        var item = junkItems[randomRare];
        if (item)
        {
            inventory.AddItem(item);
            foundAlert.text = "Found: " + item.name;
            itemPreview.sprite = item.itemImage;
            var tempColor = itemPreview.color;
            tempColor.a = 1f;
            itemPreview.color = tempColor;
            StartCoroutine(Refresh());
        }
    }
    void uncommonItem()
    {
        randomRare = (Random.Range(0, vCount));
        print(randomRare);
        var item = valueItems[randomRare];
        if (item)
        {
            inventory.AddItem(item);
            foundAlert.text = "Found: " + item.name;
            itemPreview.sprite = item.itemImage;
            var tempColor = itemPreview.color;
            tempColor.a = 1f;
            itemPreview.color = tempColor;
            StartCoroutine(Refresh());
        }
        /*Valuableitem, commonitem and uncommon item - Randomly generates a number between 0 (first index of a list) and the highest number of the relevant list
        then loads the item, gives it to the inventory, prints the item name and resets after 3 seconds*/

    }
    IEnumerator Refresh()
    {
        yield return new WaitForSeconds(5);
        foundAlert.text = "";
        var tempColor = itemPreview.color;
        tempColor.a = 0f;
        itemPreview.color = tempColor;
    }
    void Update()
    {
      /*  if (Input.GetKeyDown("space")) // Debug
        {
            valuableItem();
        }*/
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
