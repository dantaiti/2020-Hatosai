using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAcula : MonoBehaviour
{
    public GameObject TimeText;
    public int finalscore;
    public int dividedvalue=1000000;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }



    public void AcuFinalScore()
    {
        int coup = dividedvalue/(int)TimeCounter.countup;
        finalscore = (int) (ScoreManager.score + TimeCounter.countup);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
