using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject EnemyBullet;
    [SerializeField] private Transform Muzzle;
    [SerializeField] private float firerate = 1.0f;
    [SerializeField] private bool _isntinTL=false;
    private bool _isVisible;
    private bool _isMetActive;

    Renderer targetRenderer; // 判定したいオブジェクトのrendererへの参照

    void Start () 
    {
        Player = GameObject.FindWithTag("Player");
        targetRenderer = GetComponent<Renderer>();
    }
	
    void Update ()
    {
        if (!_isntinTL) return;
        if(targetRenderer.isVisible)
        {

            _isVisible = true;
            if(!_isMetActive)
            {    

                StartCoroutine(ShotCor());
            }
        }
        else
        {

            _isVisible = false;
        }
    }

    


    private IEnumerator ShotCor()
    {
        _isMetActive = true;
        while (_isVisible)
        {
            
            Shot();
            yield return new WaitForSeconds(firerate);
        }

        _isMetActive = false;
    }

    public void Shot()
    {
        GameObject EnBl = Instantiate(EnemyBullet, Muzzle.transform.position, Muzzle.transform.rotation);
        EnBl.transform.LookAt(Player.transform);
    }

}
