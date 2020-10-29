using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject EnemyBullet;
    [SerializeField] private Transform Muzzle;
    [SerializeField] private float firerate;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(ShotCor());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ShotCor()
    {
        while (true)
        {
            GameObject EnBl =Instantiate(EnemyBullet, Muzzle.transform.position,Muzzle.transform.rotation);
            EnBl.transform.LookAt(Player.transform);
            yield return new WaitForSeconds(firerate);
        }
    }
}
