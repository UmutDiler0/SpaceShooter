using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody physic;
    [SerializeField] float hiz;

    void Start()
    {
        physic = GetComponent<Rigidbody>();
        physic.velocity = transform.forward * hiz;
    }
    
}
