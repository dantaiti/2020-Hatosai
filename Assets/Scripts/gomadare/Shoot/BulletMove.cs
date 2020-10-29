using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // [SerializeField]
    // private GameObject rightpoint;
    // [SerializeField]
    // private GameObject leftpoint;
    
    // [SerializeField]
    // private GameObject shotpoint;
    private Transform transf_Bullet;
    private const float BULLET_LIFE_TIME = 3;
    private float bulletLifeTimer;
    public float movespeed=10;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bulletLifeTimer = BULLET_LIFE_TIME;
    }
    public void Init(Transform startPos) {
        transf_Bullet = GetComponent<Transform>();
        // 弾の位置と角度を設定
        transf_Bullet.position = startPos.transform.position;
        transf_Bullet.rotation = startPos.transform.rotation;

        // 弾が飛んでいられる時間を設定
        bulletLifeTimer = BULLET_LIFE_TIME;
        
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * (Time.deltaTime * movespeed);
        
        bulletLifeTimer -= Time.deltaTime;
        // 一定時間たったら弾は非アクティブにする
        if(bulletLifeTimer < 0) this.gameObject.SetActive(false);
    }
    
}
