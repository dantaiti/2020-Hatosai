using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimcontrol : MonoBehaviour
{
    [SerializeField]private GameObject aimObj;
    [SerializeField]private GameObject aimtarget;
    

    [SerializeField]private LayerMask layermask ;
    // Start is called before the first frame update
    void Start()
    {

    }

    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(gameObject.transform.position, aimObj.transform.position, out hit, Mathf.Infinity,
            layermask))
        {
            aimtarget.transform.position = hit.point;
        }
    }
}
