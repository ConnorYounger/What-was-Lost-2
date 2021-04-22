using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonPulser : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Grow parameters")]
    public float approachSpeed = 0.005f;
    public float growthBound = 1.1f;
    public float shrinkBound = 0.8f;
    private float currentRatio = 1;
    private bool keepGoing = true;

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine("StartPulsing");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopCoroutine("StartPulsing");
        transform.localScale = Vector3.one;
    }


    public IEnumerator StartPulsing()
    {
        while (keepGoing)
        {
            // Get bigger for a few seconds
            while (this.currentRatio != this.growthBound)
            {
                currentRatio = Mathf.Lerp(currentRatio, growthBound, approachSpeed);
                transform.localScale = Vector3.one * currentRatio;

                yield return new WaitForEndOfFrame();
            }

            while (this.currentRatio != this.shrinkBound)
            {
                currentRatio = Mathf.Lerp(currentRatio, shrinkBound, approachSpeed);
                transform.localScale = Vector3.one * currentRatio;

                yield return new WaitForEndOfFrame();
            }
        }
    }
}
