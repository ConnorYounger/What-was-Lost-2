using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSettings audioSettingsPrefab;

    public AudioGroup[] audioGroups;

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
        otherWeights.Clear();
        chances.Clear();

        float groupPlayChance = 1;

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

            foreach (AudioGroup otherGroup in audioGroups)
            {
                if (audioGroup != otherGroup)
                {
                    otherWeights.Add(otherGroup.groupPlayWeight);
                }
            }

            foreach (float otherWeight in otherWeights)
            {
                float chance = audioGroup.groupPlayWeight / otherWeight;
                chances.Add(chance);
            }

            foreach (float chance in chances)
            {
                groupPlayChance = groupPlayChance * chance;
            }

            audioGroup.groupPlayChance = groupPlayChance;
        }
    }
}
