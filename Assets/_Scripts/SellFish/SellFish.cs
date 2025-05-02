using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Cursor = UnityEngine.Cursor;
using Random = UnityEngine.Random;


public class SellFish : MonoBehaviour
{
    // Start is called before the first frame update
    private Scene scene;
    private string fishType;
    private GameObject targetObject;
    private Vector3 show;
    public int money;
    private Vector3 hide;
    [SerializeField] private SellUIManager sellUIManager; 

    
    
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        fishType = null;
        fishType = PlayerPrefs.GetString("FishType", "DefaultFish");
        hide = GameObject.FindGameObjectWithTag("Betta").transform.position;
        money = PlayerPrefs.GetInt("Money", 0);

    }

    // Update is called once per frame
    void Update()
    {
        int caughtM = PlayerPrefs.GetInt("CaughtAFish", 0);
        
        if (caughtM == 1)
        {
           showFish(); 
        }
    }

    void isTargetObjectAssigned()
    {                         
        if (targetObject != null)
        {
            
           
        }
        else
        {
            Debug.Log("No object with tag 'Betta' found.");
        }
    }
    

    void UnlockMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public GameObject GetTargetObject()
    {
        return targetObject;
    }

    private void OnEnable()
    {
        showFish();
    }

    void showFish()
    {
        money = PlayerPrefs.GetInt("Money", 0);
        fishType = PlayerPrefs.GetString("FishType", "DefaultFish");
        sellUIManager.CacheOldMoney(money);
        
        
       
        if (fishType == "Betta")
        {
            targetObject = GameObject.FindGameObjectWithTag("Betta");
            isTargetObjectAssigned();
            targetObject.transform.position = show;
            UnlockMouse();
            fishType = "Default";
            PlayerPrefs.SetInt("FishValue", (int)FindFishValue("Betta"));
            money = money + (int)FindFishValue("Betta");
            PlayerPrefs.SetInt("Money", money);
        } else if (fishType == "Fish")
        {
            UnlockMouse();
            targetObject = GameObject.FindGameObjectWithTag("Fish");
            isTargetObjectAssigned();
            targetObject.transform.position = show;
            fishType = "Default";
            PlayerPrefs.SetInt("FishValue", (int)FindFishValue("Fish"));
            money += (int)FindFishValue("Fish");
            PlayerPrefs.SetInt("Money", money);
        }else if (fishType == "Catfish")
        {
            UnlockMouse();
            targetObject = GameObject.FindGameObjectWithTag("Catfish");
            isTargetObjectAssigned();
            targetObject.transform.position = show;
            fishType = "Default";
            PlayerPrefs.SetInt("FishValue", (int)FindFishValue("Catfish"));
            money += (int)FindFishValue("Catfish");
            PlayerPrefs.SetInt("Money", money);
        } else if (fishType == "LionFish")
        {
            UnlockMouse();
            targetObject = GameObject.FindGameObjectWithTag("LionFish");
            isTargetObjectAssigned();
            targetObject.transform.position = show;
            fishType = "Default";
            PlayerPrefs.SetInt("FishValue", (int)FindFishValue("LionFish"));
            money += (int)FindFishValue("LionFish");
            PlayerPrefs.SetInt("Money", money);
        }
        

      
        PlayerPrefs.SetInt("CaughtAFish", 0);
    }

    float FindFishValue(String fish)
    {
        float multiplier = Random.Range(1, 10);
        if (fish == "Betta")
        {
            return (float)Math.Round(multiplier * 0.6);
        } else if (fish == "Fish")
        {
            return (float)Math.Round(multiplier * 0.4);
        } else if (fish == "Catfish")
        {
            return (float)Math.Round(multiplier * 1);
        } else if (fish == "LionFish")
        {
            return (float)Math.Round(multiplier * -0.5);
        }
        

        return 0;
    }
    
}