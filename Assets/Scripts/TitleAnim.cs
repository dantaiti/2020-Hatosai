using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class TitleAnim : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _animeStart;
   
     [SerializeField ]private DOTweenVisualManager manager;
     [SerializeField ]private DOTweenVisualManager textanimmanager;
     [SerializeField] private ParticleSystem rightParticleSystem;
     [SerializeField] private ParticleSystem leftParticleSystem;
    void Start()
    {
        
        _animeStart = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            manager.enabled = true;
           
        }
    }

   public void Test()
    {
        Debug.Log("PLAY!");
       
    }

   public void OnParticle()
   {
       rightParticleSystem.Play();
       leftParticleSystem.Play();

   }
}
