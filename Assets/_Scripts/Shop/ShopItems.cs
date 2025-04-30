using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopItems : MonoBehaviour
{
    public GameObject zebraLure;
    public GameObject iceCreamLure;
    public GameObject rainbowLure;

    public GameObject wooden;
    public GameObject golden;
    public GameObject red;

    public GameObject canvasChange;

   

    public void Trigger()
    {
        if (zebraLure.activeInHierarchy == false && iceCreamLure.activeInHierarchy == false &&
            rainbowLure.activeInHierarchy == false)
        {
            zebraLure.SetActive(true);
            iceCreamLure.SetActive(true);
            rainbowLure.SetActive(true);
            canvasChange.SetActive(false);
        }

        zebraLure.SetActive(false);
        iceCreamLure.SetActive(false);
        rainbowLure.SetActive(false);
        canvasChange.SetActive(true);
    }

    public void Trigger1()
    {
        if (wooden.activeInHierarchy == false && golden.activeInHierarchy == false && red.activeInHierarchy == false)
        {
            wooden.SetActive(true);
            red.SetActive(true);
            golden.SetActive(true);
            canvasChange.SetActive(false);

        }

        wooden.SetActive(false);
        red.SetActive(false);
        golden.SetActive(false);
        canvasChange.SetActive(true);
    }
}

   
