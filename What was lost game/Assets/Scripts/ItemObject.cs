using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Key,
    Value,
    Trash,
    Default
}
public abstract class ItemObject : ScriptableObject
{
    public GameObject invPrefab;
    public ItemType type;
    public string itemName;
    public Sprite itemImage;
    public GameObject modelPrefab;
}