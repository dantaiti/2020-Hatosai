using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPLinkText : MonoBehaviour
{ private GameObject Player;

    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = Player.GetComponentInChildren<PlayerHP>().HP;
    }
}
