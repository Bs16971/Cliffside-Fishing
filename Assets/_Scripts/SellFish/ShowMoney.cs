using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class ShowMoney : MonoBehaviour
{
    public TMP_Text numberText; // Reference to the Text component
     // A number to display
     public int money;
     private bool display;

     private void Start()
     {
         display = false;
         numberText.text = money.ToString("C0");
         UpdateTextDisplay();
     }

     private void Update()
     {
        
         money = PlayerPrefs.GetInt("Money", 0);
         Debug.Log(money);
         if (display == true)
         {
             UpdateTextDisplay();
             Debug.Log("Call");
         }
         
     }
     private void UpdateTextDisplay()
     {
         // Set the number to display, rounding it to 2 decimal places
         numberText.text = money.ToString("C0");
         display = false;
         // Displays 2 decimal places
     }

     public void Display()
     {
         display = true;
     }
}

