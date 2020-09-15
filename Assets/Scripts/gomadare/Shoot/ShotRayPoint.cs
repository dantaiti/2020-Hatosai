using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotRayPoint : MonoBehaviour
{
    private GameObject aimObj;
    private GameObject aimtarget;

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
    }
}
