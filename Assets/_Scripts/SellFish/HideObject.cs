using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HideObject : MonoBehaviour
{

    private String item;
    private GameObject thing;
    private Vector3 newPosition = new Vector3(500, 0, 0);
    public TMP_Text numberText;
    

    

    public void hide()
    {
        item = PlayerPrefs.GetString("FishType", "DefaultFish");
        Debug.Log(item);
        thing = GameObject.FindGameObjectWithTag(item);
        thing.transform.position = newPosition;
        
    }
    
}
