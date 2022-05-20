using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    [SerializeField] float missileSpeed;
    [SerializeField] float damage;

    PlayerHealth PH;

    Rigidbody RB;
    void Start()
    {
        PH = FindObjectOfType<PlayerHealth>();
        RB = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        RB.AddRelativeForce(new Vector3(missileSpeed * Time.deltaTime, 0, 0));
    }
    private void OnCollisionEnter(Collision collision)
    {
       
       if (collision.gameObject.tag == "Player")
       {
            PH.HealthDamage(damage);
       }
        
     Destroy(gameObject);
    }
   
}