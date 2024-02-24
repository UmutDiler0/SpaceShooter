using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotater : MonoBehaviour
{
    Rigidbody physics;
    [SerializeField] float hiz;
    
    void Start()
    {
        physics = GetComponent<Rigidbody>();
        physics.angularVelocity = Random.insideUnitCircle * hiz; ;
    }

    
}
