using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Character", menuName = "Enemy Characters/Enemy Character")]

public class EnemyStats : ScriptableObject
{
    public enum EnemyType { Child, Dog }
    public EnemyType enemyType;

    public string characterName;

    public float triggerDistance;
    public float movementSpeed;
    public float coolDownTime;

    [HideInInspector]
    public Vector3 startLocation;
}
