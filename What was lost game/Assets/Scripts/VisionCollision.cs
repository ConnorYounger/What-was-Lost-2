using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCollision : MonoBehaviour
{
    public GameObject parent;

    public string methodName;

    private void Start()
    {
        if (!parent)
        {
            parent = transform.parent.gameObject;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (parent)
        {
            if (parent.GetComponent<ChildrenAI>())
            {
                if (parent.GetComponent<ChildrenAI>().targetName == other.gameObject.name)
                {
                    parent.SendMessage(methodName);
                }
            }
            else
            {
                parent.SendMessage(methodName);
            }
        }
    }
}
