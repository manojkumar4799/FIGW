using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHp;
    [SerializeField] ParticleSystem HitExpo;
    [SerializeField] ParticleSystem deathVFX;

    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] TextMeshProUGUI displayHealth;
   
    AudioSource AS;
    DeathHandler DHandler;
    
    
    void Start()
    {
        DHandler = GetComponent<DeathHandler>();
        AS = GetComponent<AudioSource>();
        displayHealth.text = playerHp.ToString();
    }

  public void HealthDamage(float damage)
    {

        playerHp -= damage;
        displayHealth.text = playerHp.ToString();
        Instantiate(HitExpo,transform.position, Quaternion.identity);
       
        if (!AS.isPlaying)
        {
            AS.PlayOneShot(hitSound);
        }
        if(playerHp<=0)
        {
            DeathProcess();
        }
    }
   

    private void DeathProcess()
    {
        
        Instantiate(deathVFX, transform.position, Quaternion.identity);
        Instantiate(deathSound, transform.position, Quaternion.identity);
        GetComponent<PlayerControl>().enabled = false;
        GetComponent<Animator>().SetTrigger("DEATH");
        DHandler.DisplayDeath();

     }
    

    
}
