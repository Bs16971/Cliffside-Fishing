using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class ShopText : MonoBehaviour
{

    public GameObject woodenRod;
    public GameObject redRod;
    public GameObject goldenRod;

    public GameObject zebraLure;
    public GameObject iceCreamLure;
    public GameObject rainbowLure;

    public void TurnOnRod(int rod)
    {
        Debug.Log("Works");
        
        switch (rod)
        {
            case 0:
                woodenRod.SetActive(true);
                break;
            
            case 1:
                redRod.SetActive(true);
                break;
            
            case 2:
                goldenRod.SetActive(true);
                break;
        }
    }

    public void TurnOnLure(int lure)
    {
        switch (lure)
        {
            case 0:
                zebraLure.SetActive(true);
                break;
            
            case 1:
                iceCreamLure.SetActive(true);
                break;
            
            case 2:
                rainbowLure.SetActive(true);
                break;
        }
    }
}
