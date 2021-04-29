using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActivator : MonoBehaviour
{
    public GameObject menuCanvas, optionsCanvas;

    private void Start()
    {
        menuCanvas.SetActive(true);
        optionsCanvas.SetActive(true);

    }
}
