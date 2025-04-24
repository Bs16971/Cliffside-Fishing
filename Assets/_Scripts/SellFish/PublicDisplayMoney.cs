using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PublicDisplayMoney : MonoBehaviour
{
    // Start is called before the first frame update
    public int money;
    public TMP_Text numberText;
    private void Update()
    {
        
        money = PlayerPrefs.GetInt("Money", 0);
        
            UpdateTextDisplay();
            
        
    }
    private void UpdateTextDisplay()
    {
        // Set the number to display, rounding it to 2 decimal places
        numberText.text = money.ToString("C0");
        
        // Displays 2 decimal places
    }

}
