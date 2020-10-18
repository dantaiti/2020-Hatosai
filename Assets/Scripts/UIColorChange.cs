using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIColorChange : MonoBehaviour
{
  
   
    public Image visualGauge;
    
    private void Update()
    {
        Color red = new Color(0.01f, 0, 0, 0);
        Color green = new Color(0, 0.01f, 0, 0);
        if (visualGauge.fillAmount > 0.5f)
        {
            visualGauge.color += red;
        }
        
        if (visualGauge.fillAmount < 0.5f)
        {
            visualGauge.color -= green;
        }
    }

   public void ColorChange( float boostEconomy)
    {
        
    }

}
