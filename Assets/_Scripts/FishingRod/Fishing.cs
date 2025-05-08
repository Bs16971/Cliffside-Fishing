using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public GameObject[] rods; // Array of rod GameObjects (Wooden, Red, Golden)
    public GameObject[] lures; // Array of lure GameObjects (Zebra, Ice Cream, Rainbow)

    void Start()
    {
        // Equip the rod based on PlayerPrefs
        int rodIndex = PlayerPrefs.GetInt("EquippedRod", 0); // Default to 0 if no rod is equipped
        EquipRod(rodIndex);

        // Equip the lure based on PlayerPrefs
        int lureIndex = PlayerPrefs.GetInt("EquippedLure", 0); // Default to 0 if no lure is equipped
        EquipLure(lureIndex);
    }

    void EquipRod(int rodIndex)
    {
        // Disable all rods first
        foreach (var rod in rods)
        {
            rod.SetActive(false);
        }

        // Activate the selected rod
        if (rodIndex >= 0 && rodIndex < rods.Length)
        {
            rods[rodIndex].SetActive(true);
        }
    }

    void EquipLure(int lureIndex)
    {
        // Disable all lures first
        foreach (var lure in lures)
        {
            lure.SetActive(false);
        }

        // Activate the selected lure
        if (lureIndex >= 0 && lureIndex < lures.Length)
        {
            lures[lureIndex].SetActive(true);
        }
    }
}
