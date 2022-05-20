using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControl : MonoBehaviour
{
    
    
    [SerializeField] float obstacleHit;
    [SerializeField] ParticleSystem finishVFX;
    [SerializeField] Canvas winCanvas;
    
   
    PlayerHealth PH;

    DeathHandler DHandler;

  
    void Start()
    {
        DHandler = GetComponent<DeathHandler>();
        PH =GetComponent<PlayerHealth>();
        winCanvas.enabled = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="start")
        {
            return;
        }
        if(collision.gameObject.tag=="Win")
        {
            Winprocess();
        }
        else
        {

            PH.HealthDamage(obstacleHit);
        }
    }

    private void Winprocess()
    {
        finishVFX.Play();
        StartCoroutine(WinDisplay());
    }
    IEnumerator WinDisplay()
    {
        
        yield return new WaitForSeconds(1);
        winCanvas.enabled = true;
        Time.timeScale = 0f;
    }
}
