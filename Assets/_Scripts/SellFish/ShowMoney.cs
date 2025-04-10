using TMPro;
using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class ShowMoney : MonoBehaviour
{
    public TMP_Text numberText; // Reference to the Text component
     // A number to display
     public int money;
     private void Update()
     {
        
         money = PlayerPrefs.GetInt("Money", 0);
     }
     public void UpdateTextDisplay()
     {
         // Set the number to display, rounding it to 2 decimal places
         numberText.text = money.ToString("C0"); // Displays 2 decimal places
     }
}

