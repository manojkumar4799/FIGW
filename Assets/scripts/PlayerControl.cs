using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float thrustSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] AudioClip thrustSound;
    [SerializeField] ParticleSystem thrustVFX;


    bool buttonDown= false;
    bool rightTurn = false;
    bool leftTurn = false;

   

    Rigidbody rb;
    AudioSource AS;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        AS = GetComponent<AudioSource>();
        
    }

    public void PointerDown()
    {
        buttonDown = true;
    }
    public void PointerUp()
    {
        buttonDown = false;
    }


    public void RightPointerDown()
    {
        rightTurn = true;
    }
    public void RightPointerUp()
    {
        rightTurn = false;
    }


    public void LeftPointerDown()
    {
        leftTurn = true;
      
    }
    public void LeftPointerUp()
    {
        leftTurn = false;
        
    }

    void Update()
    {
        if (rightTurn)
        {
            RightTurn();
        }

        if (leftTurn)
        {
            LeftTurn();
        }

        if (buttonDown)
        {
            PlayerThrust();
            
        }
        else
        {
            StopThrustProcess();
        }
    }

   

    //private void PlayerRotate()
   // {
      // if(Input.GetKey(KeyCode.RightArrow))
      //  {
     
            

       // }
       // if (Input.GetKey(KeyCode.LeftArrow))
       // {
          ///////////// LeftTurn();
       // }
    //}

    public void LeftTurn()
    {
       
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        rb.freezeRotation = false;
    }

    public void RightTurn()
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * -rotateSpeed * Time.deltaTime);
        rb.freezeRotation = false;
    }

   public void PlayerThrust()
   {
    // if (Input.GetKey(KeyCode.Space))
    // {
       
           rb.AddRelativeForce(new Vector3(0, thrustSpeed * Time.deltaTime, 0));
           GetComponent<Animator>().SetBool("FLY", true);
        if (!AS.isPlaying)
        {
            AS.PlayOneShot(thrustSound);
            thrustVFX.Play();

        }
        if (!thrustVFX.isPlaying)
        {
            thrustVFX.Play();
        }

    // }
      
    }
    private void StopThrustProcess()// else
    {
        AS.Stop();
        thrustVFX.Stop();
        GetComponent<Animator>().SetBool("FLY", false);

    }

}
