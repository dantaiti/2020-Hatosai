using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Item : MonoBehaviour
{
    private Transform _transform;
    public Sequence seq;
    public enum ItemType
    {
        SpeedUp,
        TurnSpeedUp,
        BoostUp,
        PowerUp
    }

    private void Start()
    {

        seq = DOTween.Sequence().Append(transform.DOPunchScale(Vector3.one/3, .3f, 10, 1))
            .Pause()
            .SetAutoKill(false)
            .OnComplete(() => {
            // アニメーションが終了時によばれる
            Debug.Log("Complete!");
        });
            
         
        
    }

    public ItemType itemType;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))  seq.Restart();
       
    }
}
