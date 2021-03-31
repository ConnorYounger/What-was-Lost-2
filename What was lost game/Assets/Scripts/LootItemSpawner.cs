using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItemSpawner : MonoBehaviour
{
    [HideInInspector]
    public List<ItemObject> keyItems = new List<ItemObject>();
    public List<ItemObject> valueItems = new List<ItemObject>();
    public List<ItemObject> trashItems = new List<ItemObject>();

    [Header("Spawn Boundaries")]
    public int minPosX = -500;
    public int maxPosX = 280;
    public int minPosZ = -60;
    public int maxPosZ = -350;

    [Header("Spawn Variables")]
    [Space]
    public Vector3 spawnPoint = new Vector3();
    public int itemsToSpawn = 10;

    [Space]
    public LayerMask beachMask;

    private void Start()
    {
        PopulateLists();
        SpawnItems();
    }

    private void SpawnItems()
    {
        spawnPoint = GenerateRandomPosition();

        //raycast from spawnpoint down
        //if !trigger spawnzone tag get new spawnpoint
        //if trigger beachgroup tag get new spawnpoint
        //else instantiate an item

        Ray ray = new Ray(spawnPoint, Vector3.down);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.CompareTag("BeachGroup") || hitInfo.collider.CompareTag("SpawnZone"))
            {

            }
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        int xPos = UnityEngine.Random.Range(minPosX, maxPosX);
        int zPos = UnityEngine.Random.Range(minPosZ, maxPosZ);

        return new Vector3(xPos, 50, zPos);
    }

    private void PopulateLists()
    {
        ItemObject[] keyObjs = Resources.LoadAll<ItemObject>("Inventory/KeyItems/");
        ItemObject[] valueObjs = Resources.LoadAll<ItemObject>("Inventory/ValueItems/");
        ItemObject[] trashObjs = Resources.LoadAll<ItemObject>("Inventory/TrashItems/");
        
        foreach (ItemObject i in keyObjs) { keyItems.Add(i); }
        foreach (ItemObject i in valueObjs) { valueItems.Add(i); }
        foreach (ItemObject i in trashObjs) { trashItems.Add(i); }
    }
}
