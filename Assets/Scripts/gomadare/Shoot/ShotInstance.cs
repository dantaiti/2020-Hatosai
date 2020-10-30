using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotInstance : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float Firerate;
    private bool isShot=false;
    public Transform startPos;


    private int layermask = 1 << 8;
    // Start is called before the first frame update
    void Start()
    {

    }

    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {


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
            Instantiate(bullet, startPos.position,startPos.rotation);
            yield return new WaitForSeconds(Firerate);
        }
    }

    public void changeBool(bool isShot)
    {
        isShot = false;
    }
}
