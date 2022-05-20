using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas deathCanvas;
    [SerializeField] float displayAfter;
    void Start()
    {
        deathCanvas.enabled = false;
    }

    public void DisplayDeath()
    {
        StartCoroutine(Die());
        
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(displayAfter);
        deathCanvas.enabled = true;
        Time.timeScale = 0f;
    }

    
}
