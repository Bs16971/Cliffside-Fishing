using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fish Data", menuName ="Fish Stats")]

public class FishData : ScriptableObject
{
    public int weight;
    public int worthPerPound;
    public int speed;
}
