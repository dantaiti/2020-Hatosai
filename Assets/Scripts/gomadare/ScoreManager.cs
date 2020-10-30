using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text _text;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        
        _text = this.gameObject.GetComponent<Text>();
        _text.text = "Score:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "Score:" + score;
    }
}
