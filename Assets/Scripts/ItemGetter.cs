using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemGetter : MonoBehaviour
{
    [SerializeField] private PlayerMover player;
    
    [Header("PowerUp Values")]
    [SerializeField]private float speedUpValue; 
    [SerializeField]private float turnspeedUpValue;
    [SerializeField]private float boostMagniUpValue;
    void Start()
    {
        player = this.GetComponent<PlayerMover>();
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Item.ItemType getitemType = other.GetComponent<Item>().itemType;
            if (getitemType == Item.ItemType.SpeedUp) 
            {
                player.forwardSpeed += speedUpValue;
                if (player.isBoost == false && player.isBreak ==false)
                {
                    player.SetSpeed(player.forwardSpeed);
                    Debug.Log("スピード アップ");
                }
                // player.SetSpeed(player.forwardSpeed);
            
            }
            if (getitemType == Item.ItemType.TurnSpeedUp)
            {
                player.xyspeed += turnspeedUpValue;
            }
            if (getitemType == Item.ItemType.BoostUp)
            {
                player.boostMagni += boostMagniUpValue;
            }
        }
       
    }
}
