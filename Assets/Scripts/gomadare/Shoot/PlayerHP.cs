using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public GameObject GameOver;
    [SerializeField] private float invinsibleTime=2.0f;
    private bool isInvisible;
    public float HP=1;
    public GameObject Effect;
    // Start is called before the first frame update
    void Start()
    {
        Effect = GameObject.Find("YellB");
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            //GameOver時の処理
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isInvisible) return;
        
        if (other.CompareTag("Bullet"))
        {
            HP -= other.GetComponent<BulletMove>().Attackpower;
        }

        if (other.CompareTag("Item"))
        {
            
        }
        else
        {
            HP -= 0.2f;
        }
        isInvisible = true;
        Instantiate(Effect,transform.position,Quaternion.identity);
        if (HP <= 0)
        {
            GameOver.SetActive(true);
        }
        Invoke("inviChange",invinsibleTime);
    }

    private void inviChange()
    {
        isInvisible = false; 
    }
}
