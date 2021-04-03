using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSettings audioSettingsPrefab;

    public AudioGroup[] audioGroups;

    [Range(0, 100)] public float waveSoundWeight = 50;
    [Range(0, 100)] public float birdSoundWeight = 50;

    public float waveSoundChance;
    public float birdSoundChance;

    private List<float> otherWeights = new List<float>();
    private List<float> chances = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateSoundChances();
    }

    private void CalculateSoundChances()
    {
        foreach (AudioGroup audioGroup in audioGroups)
        {
            foreach (AudioSound sound in audioGroup.audioSounds)
            {
                otherWeights.Clear();
                chances.Clear();

                float playChance = 1;

                foreach (AudioSound otherSound in audioGroup.audioSounds)
                {
                    if (sound != otherSound)
                    {
                        otherWeights.Add(otherSound.playWeight);
                    }
                }

                foreach (float otherWeight in otherWeights)
                {
                    float chance = sound.playWeight / otherWeight;
                    chances.Add(chance);
                }

                foreach (float chance in chances)
                {
                    playChance = playChance * chance;
                }

                sound.playChance = playChance;
            }
        }
    }
}
