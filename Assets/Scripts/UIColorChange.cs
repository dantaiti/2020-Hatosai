using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIColorChange : MonoBehaviour
{
  
   
    private Image _visualGauge;
   
    private void Start()
    {
        _visualGauge =GetComponent<Image>();
        
    }

    private void Update()
    {
        
        if (_visualGauge.fillAmount <0.2f)
        {
            _visualGauge.color = new Color(255,0,0,255);
            
        }
        
        if (_visualGauge.fillAmount < 0.5f && _visualGauge.fillAmount > 0.2f) 
        {
            _visualGauge.color = new Color(255,255,0,255);
        }

        if (_visualGauge.fillAmount>=0.5f)
        {
            _visualGauge.color = new Color(0,255,0,255);
        }
        if(_visualGauge.fillAmount==1f)
        {
            _visualGauge.color = new Color(0,255,255,255);
        }

    }

   

}
