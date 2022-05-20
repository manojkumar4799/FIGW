using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscillation : MonoBehaviour
{
    [SerializeField] float XRotation;
    [SerializeField] float YRotation;
    [SerializeField] float ZRotation;

    

    void Update()
    {
        transform.Rotate(XRotation*Time.deltaTime,YRotation * Time.deltaTime, ZRotation * Time.deltaTime);  
    }
}
