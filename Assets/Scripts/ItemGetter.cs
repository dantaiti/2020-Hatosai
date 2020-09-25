using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGetter : MonoBehaviour
{
    [SerializeField] private PlayerMover player;
    void Start()
    {
        player = this.GetComponent<PlayerMover>();
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Item>().itemType == Item.ItemType.SpeedUp)
        {
            player.forwardSpeed += 5f;
            player.SetSpeed(player.forwardSpeed);
            
        }
        if (other.GetComponent<Item>().itemType == Item.ItemType.TurnSpeedUp)
        {
            player.xyspeed += 2f;
        }
        if (other.GetComponent<Item>().itemType == Item.ItemType.BoostUp)
        {
            player.boostMagni += 0.1f;
        }
        
    }
}
