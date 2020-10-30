using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // public GameObject ScoreText;
    // private ScoreManager scm;
    public int HP;
    public int Attack;
    public int Enemyscore;
    public GameObject Effect;
    
    public 
    // Start is called before the first frame update
    void Start()
    {
        Effect = GameObject.Find("YellB");
        // ScoreText = GameObject.Find("ScoreText");
        // scm = ScoreText.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.tag == "Bullet")
        {
            HP--;
            if (HP == 0)
            {
                ScoreManager.score += Enemyscore;
                this.gameObject.SetActive(false);
                Instantiate(Effect,transform.position,Quaternion.identity);

            }
        }
    }
}
