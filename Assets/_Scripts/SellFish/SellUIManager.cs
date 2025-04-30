using UnityEngine;
using TMPro;  // Make sure this is included for TextMeshPro

public class SellUIManager : MonoBehaviour
{
    public TMP_Text moneyText;   // Drag your TMP_Text UI element here in the Inspector

    private int cachedOldMoney;  // Money before the sale

    // Cache the money before it's changed in showFish()
    public void CacheOldMoney(int oldMoney)
    {
        cachedOldMoney = oldMoney;
        moneyText.text = cachedOldMoney.ToString("C0"); // Show cached money as currency
    }

    // Call this method to update the UI when the sale is revealed
    public void RevealUpdatedMoney()
    {
        int newMoney = PlayerPrefs.GetInt("Money", 0);
        moneyText.text = newMoney.ToString("C0");  // Show new money after update
    }
}