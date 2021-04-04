using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSettings audioSettingsPrefab;

    public AudioGroup[] audioGroups;

    private List<float> otherWeights = new List<float>();
    private List<float> chances = new List<float>();

    void Update()
    {
        CalculateSoundChances();
    }

    // Calculate the sound play chances relative to the other sounds in the sound group
    private void CalculateSoundChances()
    {
        // These lists are use as local variables for calculating the sound chances
        otherWeights.Clear();
        chances.Clear();

        float groupPlayChance = 1;

        // Search through all of the audio groups in the array
        foreach (AudioGroup audioGroup in audioGroups)
        {
            // For each audio group, search through every sound in the audio group
            foreach (AudioSound sound in audioGroup.audioSounds)
            {
                // Reset the local variables for each sound
                otherWeights.Clear();
                chances.Clear();

                float playChance = 1;

                // Search through all of the sounds in the audio group that arn't the current sound and save it to the other weights list
                foreach (AudioSound otherSound in audioGroup.audioSounds)
                {
                    if (sound != otherSound)
                    {
                        otherWeights.Add(otherSound.playWeight);
                    }
                }

                // Next Calculate the chance of each sound relative to each other and add it to the chances list
                foreach (float otherWeight in otherWeights)
                {
                    float chance = sound.playWeight / otherWeight;
                    chances.Add(chance);
                }

                // Add all of the chances together
                foreach (float chance in chances)
                {
                    playChance = playChance * chance;
                }

                // Assign the chance to the sound scriptable object
                sound.playChance = playChance;
            }

            // Search for all of the audio groups that arn't the current group and their weights 
            foreach (AudioGroup otherGroup in audioGroups)
            {
                if (audioGroup != otherGroup)
                {
                    otherWeights.Add(otherGroup.groupPlayWeight);
                }
            }

            // Next Calculate the chance of each audio groups relative to each other and add it to the chances list
            foreach (float otherWeight in otherWeights)
            {
                float chance = audioGroup.groupPlayWeight / otherWeight;
                chances.Add(chance);
            }

            // Add all of the chances together
            foreach (float chance in chances)
            {
                groupPlayChance = groupPlayChance * chance;
            }

            // Assign the chance to the audio group scriptable object
            audioGroup.groupPlayChance = groupPlayChance;
        }
    }
}
