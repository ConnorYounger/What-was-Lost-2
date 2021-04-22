using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Character", menuName = "Enemy Characters/Enemy Character")]

public class EnemyStats : ScriptableObject
{
    public enum EnemyType { Child, Dog }
    public EnemyType enemyType;

    [Header("Stats")]
    public string characterName;
    public float triggerDistance;
    public float movementSpeed;
    public float coolDownTime;

    public string itemReturnMessage;

    [HideInInspector]
    public Vector3 startLocation;

    [Header("Sounds")]
    public AudioClip triggerSound;
    public AudioClip footStepSound;
    public float timeBetweenFootStepSounds = 0.5f;
}
