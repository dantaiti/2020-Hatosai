using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    //カウントアップ
    public static float countup = 0.0f;
 
    //タイムリミット
    public float timeLimit = 5.0f;

    public float minutes=0;

    public float seconds=0;
    //時間を表示するText型の変数
    public Text timeText;
 
    // Update is called once per frame
    void Update()
    {
        //時間をカウントする
        countup += Time.deltaTime;
         seconds += Time.deltaTime;
        if (seconds >= 60)
        {
            seconds -= 60;
            minutes += 1;
        }
        
 
        //時間を表示する
        timeText.text = "0"+Mathf.FloorToInt(minutes).ToString("f1") + ":" + seconds.ToString("f1");
 
        
    }
}
