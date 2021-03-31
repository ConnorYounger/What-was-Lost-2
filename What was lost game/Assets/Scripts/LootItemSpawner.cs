using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItemSpawner : MonoBehaviour
{
    [HideInInspector]
    public List<ItemObject> keyItems = new List<ItemObject>();
    [HideInInspector]
    public List<ItemObject> valueItems = new List<ItemObject>();
    [HideInInspector]
    public List<ItemObject> trashItems = new List<ItemObject>();

    [Header("Spawn Boundaries")]
    public int minPosX;
    public int maxPosX;
    public int minPosZ;
    public int maxPosZ;

    [Header("Spawn Variables")]
    [Space]
    public LayerMask beachMask;
    public LayerMask triggerMask;
    public GameObject objectToSpawn;
    public int itemsToSpawn = 10;

    //public Vector3 spawnPoint = new Vector3();
    //public List<GameObject> spawnPoints = new List<GameObject>();
    //public int pointsSpawned;
    //public bool canInstantiate = false;

    private void Start()
    {
        //PopulateLists();

        GenerateSpawnPoints();
        //SpawnItems();
    }

    private void GenerateSpawnPoints()
    {
        for (int i = 0; i < itemsToSpawn; i++)
        {
            Debug.Log("start: "+i);

            var spawnPoint = GenerateRandomPosition();

            RaycastHit hitInfo;
            var hitPoint = Physics.Raycast(spawnPoint, Vector3.down, out hitInfo, Mathf.Infinity, beachMask);


            var newSpawn = Instantiate(objectToSpawn, hitInfo.point, Quaternion.identity);
            Collider[] hitColliders = Physics.OverlapSphere(newSpawn.transform.position, 1f, triggerMask, QueryTriggerInteraction.UseGlobal);

            //VerifySpawnPoint();
            if (hitColliders.Length == 0)
            {
                Debug.Log("No collisions");
                Destroy(newSpawn);
                i--;
            } else
            {
                foreach (var collision in hitColliders)
                {
                    Debug.Log("Check collisions");

                    if (!collision.CompareTag("SpawnZone"))
                    {
                        Debug.Log("decrement: " + i);
                    }
                }
            }
        }
    }

    private void VerifySpawnPoint() {

    }

    /*
    private void SpawnItems()
    {
        for (int i = 0; i < itemsToSpawn; i++)
        {
            CreateSpawnPoints();
        }
    }*/

    /*
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
                else if (hitCollider.CompareTag("SpawnZone"))
                {
                    newSpawn = Instantiate(objectToSpawn, hitInfo.point, Quaternion.identity);
                    spawnPoints.Add(newSpawn);
                }
                pointsSpawned++;
            }
        }
    }*/

    private Vector3 GenerateRandomPosition()
    {
        int xPos = UnityEngine.Random.Range(minPosX, maxPosX);
        int zPos = UnityEngine.Random.Range(minPosZ, maxPosZ);

        return new Vector3(xPos, 150, zPos);
    }

    /*
    private void PopulateLists()
    {
        ItemObject[] keyObjs = Resources.LoadAll<ItemObject>("Inventory/KeyItems/");
        ItemObject[] valueObjs = Resources.LoadAll<ItemObject>("Inventory/ValueItems/");
        ItemObject[] trashObjs = Resources.LoadAll<ItemObject>("Inventory/TrashItems/");

        foreach (ItemObject i in keyObjs) { keyItems.Add(i); }
        foreach (ItemObject i in valueObjs) { valueItems.Add(i); }
        foreach (ItemObject i in trashObjs) { trashItems.Add(i); }
    }*/
}