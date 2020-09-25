using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        SpeedUp,
        TurnSpeedUp,
        BoostUp,
        PowerUp
    }
   
    public ItemType itemType;

}
