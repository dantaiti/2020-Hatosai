using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Item : MonoBehaviour
{
    private GameObject _player;
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
    {        _player = GameObject.Find("Player");

        /*
        seq = DOTween.Sequence().Append(transform.DOPunchScale(Vector3.one/3, .3f, 10, 1))
            .Append(transform.DOMove())
            .Pause()
            .SetAutoKill(false)
            .OnComplete(() => {
            // アニメーションが終了時によばれる
            Debug.Log("Complete!");
        });
            
        */
        
        
    }

    public ItemType itemType;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))  PlayAnimation();//seq.Restart();
       
    }

    private void PlayAnimation()
    { Vector3 target = _player.transform.position;
        
            DOTween.Sequence()
                .Append(transform.DOMove(target,0.1f))
                .SetAutoKill(false)
                .OnComplete(() => {
                // アニメーションが終了時によばれる
                
                    Destroy(gameObject);
            });
    }
}
