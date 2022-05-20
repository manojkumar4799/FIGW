using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
    [SerializeField] GameObject missile;
    [SerializeField] float missileTimeInterval;
    [SerializeField] AudioClip missileLaunchSFX;
    [SerializeField] ParticleSystem missileLaunchVFX;



    AudioSource AS;
    void Start()
    {
        Launch();
        AS=GetComponent<AudioSource>();
    }
   private void Launch()
   {
        GetComponent<Animator>().SetBool("ACTION", true);
    }
   
    public void SoundEffect()
    {
        AS.PlayOneShot(missileLaunchSFX);
        
        
    }

   private void MissileMAchineAction()
   {
        Instantiate(missile, transform.position, Quaternion.identity);
        missileLaunchVFX.Play();
        GetComponent<Animator>().SetBool("ACTION", false);
        StartCoroutine(PostLaunch());
   }
    IEnumerator PostLaunch()
    {
        yield return new WaitForSeconds(missileTimeInterval);
        Launch();
    }
}
