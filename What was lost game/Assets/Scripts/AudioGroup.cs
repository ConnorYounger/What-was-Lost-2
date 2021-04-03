using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Audio Group", menuName = "Audio/Audio Group")]

public class AudioGroup : ScriptableObject
{
    public AudioSound[] audioSounds;
}
