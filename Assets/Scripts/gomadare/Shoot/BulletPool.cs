using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    // エディタから弾として使うプレハブを設定
    public GameObject pf_Bullet;
    // 弾を備蓄しておくList
    List<BulletMove> list_Bullets = new List<BulletMove>();
    // 備蓄しておく弾の数
    const int MAX_BULLETS = 15;

    void Start () {
        BulletMove bullet;
        // 最初に一定数の弾を備蓄しておく
        for(int i=0; i<MAX_BULLETS; i++) {
            // 弾の生成
            bullet = ((GameObject) Instantiate(pf_Bullet)).GetComponent<BulletMove>();
            // 弾を、この「BulletGenerator」オブジェクトの子にしておく
            bullet.transform.parent = this.transform;
            // 発射前は非アクティブにしておく
            bullet.gameObject.SetActive(false);
            // Listに追加
            list_Bullets.Add(bullet);
        }
    }

    public void FireBullet(Transform startPos)
    {
        // Listの中身を最初から確認していき、非アクティブのオブジェクトを探す
        for (int i = 0; i < list_Bullets.Count; i++)
        {
            if (list_Bullets[i].gameObject.activeSelf == false)
            {
                // 非アクティブの弾を発射させる
                list_Bullets[i].Init(startPos);
                return;
            }
        }
    }
}
