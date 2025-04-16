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
    public GameObject rodButton;

    public GameObject zebraLure;
    public GameObject iceCreamLure;
    public GameObject rainbowLure;
    public GameObject lureButton;

    public void TurnOnRod(int rod)
    {
        
        
        switch (rod)
        {
            case 0:
                woodenRod.SetActive(true);
                rodButton.SetActive(true);
                lureButton.SetActive(false);
                
                break;
            
            case 1:
                redRod.SetActive(true);
                rodButton.SetActive(true);
                lureButton.SetActive(false);
                break;
            
            case 2:
                goldenRod.SetActive(true);
                rodButton.SetActive(true);
                lureButton.SetActive(false);
                break;
        }
    }

    public void TurnOnLure(int lure)
    {
        switch (lure)
        {
            case 0:
                zebraLure.SetActive(true);
                rodButton.SetActive(false);
                lureButton.SetActive(true);
                PlayerPrefs.SetInt("HookSpeed", 10);
                break;
            
            case 1:
                iceCreamLure.SetActive(true);
                rodButton.SetActive(false);
                lureButton.SetActive(true);
                PlayerPrefs.SetInt("HookSpeed", 15);
                break;
            
            case 2:
                rainbowLure.SetActive(true);
                rodButton.SetActive(false);
                lureButton.SetActive(true);
                PlayerPrefs.SetInt("HookSpeed", 20);
                break;
        }
    }
    
    
}
