using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotRayPoint : MonoBehaviour
{
    [SerializeField] private float Firerate;
    private bool isShot=false;
    public Transform startPos;
    private GameObject aimObj;
    private GameObject aimtarget;

    public BulletPool bulletPool;

    private int layermask = 1 << 8;
    // Start is called before the first frame update
    void Start()
    {
        aimObj = GameObject.Find("aimObj");
        aimtarget = GameObject.Find("aimtarget");
        
    }

    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        
        if (Physics.Raycast(gameObject.transform.position, aimObj.transform.position, out hit,Mathf.Infinity,layermask))
        {
            aimtarget.transform.position=hit.point;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            isShot = true;
            StartCoroutine("FireBulletCorutine");
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            isShot = false;
        }
    }

    IEnumerator FireBulletCorutine()
    {
        while (isShot)
        {
            bulletPool.FireBullet(startPos);
            yield return new WaitForSeconds(Firerate);
        }
    }

    public void changeBool(bool isShot)
    {
        isShot = false;
    }
}
