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

    public GameObject broke;

    public void TurnOnRod(int rod)
    {

        int money = PlayerPrefs.GetInt("Money", 0);
        switch (rod)
        {
            case 0:
                if (money >= 10)
                {
                    woodenRod.SetActive(true);
                    rodButton.SetActive(true);
                    lureButton.SetActive(false);
                    money -= 10;
                    PlayerPrefs.SetInt("Money", money);
                    PlayerPrefs.SetInt("Chance", 6);
                    PlayerPrefs.SetInt("EquippedRod", 0);
                }
                else
                {
                    broke.SetActive(true);
                }

                break;
            
            case 1:
                if (money >= 15)
                {
                    redRod.SetActive(true);
                    rodButton.SetActive(true);
                    lureButton.SetActive(false);
                    money -= 15;
                    PlayerPrefs.SetInt("Money", money);
                    PlayerPrefs.SetInt("Chance", 8);
                    PlayerPrefs.SetInt("EquippedRod", 1);
                }
                else
                {
                    broke.SetActive(true);
                }

                break;
            
            case 2:
                if (money >= 20)
                {
                    goldenRod.SetActive(true);
                    rodButton.SetActive(true);
                    lureButton.SetActive(false);
                    money -= 20;
                    PlayerPrefs.SetInt("Money", money);
                    PlayerPrefs.SetInt("Chance", 10);
                    PlayerPrefs.SetInt("EquippedRod", 2);
                }
                else
                {
                    broke.SetActive(true);
                }

                break;
        }
    }

    public void TurnOnLure(int lure)
    {
        int money = PlayerPrefs.GetInt("Money", 0);
        switch (lure)
        {
            case 0:
                if (money >= 5)
                {
                    zebraLure.SetActive(true);
                    rodButton.SetActive(false);
                    lureButton.SetActive(true);
                    PlayerPrefs.SetInt("HookSpeed", 10);
                    money -= 5;
                    PlayerPrefs.SetInt("Money", money);
                    PlayerPrefs.SetInt("EquippedLure", 0);
                }
                else
                {
                     broke.SetActive(true);
                }

                break;
            
            case 1:
                if (money >= 10)
                {
                    iceCreamLure.SetActive(true);
                    rodButton.SetActive(false);
                    lureButton.SetActive(true);
                    PlayerPrefs.SetInt("HookSpeed", 15);
                    money -= 10;
                    PlayerPrefs.SetInt("Money", money);
                    PlayerPrefs.SetInt("EquippedLure", 1);
                }
                else
                {
                    broke.SetActive(true);
                }

                break;
            
            case 2:
                if (money >= 15)
                {
                    rainbowLure.SetActive(true);
                    rodButton.SetActive(false);
                    lureButton.SetActive(true);
                    PlayerPrefs.SetInt("HookSpeed", 20);
                    money -= 15;
                    PlayerPrefs.SetInt("Money", money);
                    PlayerPrefs.SetInt("EquippedLure", 2);
                }
                else
                {
                    broke.SetActive(true);
                }

                break;
        }
    }
    
    
}