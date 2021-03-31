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
    public GameObject spawnTest;
    //public Vector3 spawnPoint = new Vector3();
    public List<GameObject> spawnPoints = new List<GameObject>();
    public int itemsToSpawn = 10;
    public int pointsSpawned;
    public bool canInstantiate = false;

    [Space]
    public LayerMask beachMask;

    private void Start()
    {
        PopulateLists();
        SpawnItems();
    }

    private void SpawnItems()
    {
            for (int i = 0; i < itemsToSpawn; i++)
            {
                CreateSpawnPoints();
            }
    }

    private void CreateSpawnPoints()
    {
        var spawnPoint = GenerateRandomPosition();

        RaycastHit hitInfo;
        var hitPoint = Physics.Raycast(spawnPoint, Vector3.down, out hitInfo, Mathf.Infinity, beachMask);
        GameObject newSpawn;

        if (hitPoint)
        {
            Collider[] hitColliders = Physics.OverlapSphere(hitInfo.point, 1f);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("BeachGroup"))
                {
                    pointsSpawned++;

                    Debug.Log("This text should never happen");
                }
                else if (hitCollider.CompareTag("SpawnZones"))
                {
                    newSpawn = Instantiate(spawnTest, hitInfo.point, Quaternion.identity);
                    spawnPoints.Add(newSpawn);
                }
                pointsSpawned++;
            }
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        int xPos = UnityEngine.Random.Range(minPosX, maxPosX);
        int zPos = UnityEngine.Random.Range(minPosZ, maxPosZ);

        return new Vector3(xPos, 150, zPos);
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