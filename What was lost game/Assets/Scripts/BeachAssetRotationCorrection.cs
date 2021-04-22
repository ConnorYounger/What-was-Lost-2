using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachAssetRotationCorrection : MonoBehaviour
{
    public GameObject[] assetRotationAndPosition;
    public GameObject[] beachPosition;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject beachAsset in assetRotationAndPosition)
        {
            RaycastHit hit;
            if(Physics.Raycast(beachAsset.transform.position, Vector3.down, out hit, 10))
            {
                beachAsset.transform.position = hit.point;

                beachAsset.transform.rotation = new Quaternion(hit.normal.x, transform.rotation.y, hit.normal.z, transform.rotation.w);
            }
        }

        foreach (GameObject beachAsset in beachPosition)
        {
            RaycastHit hit;
            if (Physics.Raycast(beachAsset.transform.position, Vector3.down, out hit, 10))
            {
                beachAsset.transform.position = hit.point;
            }
        }
    }
}
