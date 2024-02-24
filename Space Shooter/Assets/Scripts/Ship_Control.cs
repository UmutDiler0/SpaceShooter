using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Boundry
{
    public float xMin, xMax, zMin, zMax;
}
public class Ship_Control : MonoBehaviour
{
    
    Rigidbody physic;
    AudioSource audioPlayer;

    [SerializeField] int speed;
    [SerializeField] int slope;
    [SerializeField] float nextFire;
    [SerializeField] float fireRate;


    public Boundry boundry;
    public GameObject shot;
    public GameObject shotspawn;
    
    


    void Start()
    { 
        physic = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotspawn.transform.position, shotspawn.transform.rotation);
            audioPlayer.Play();
        }
    }
    void FixedUpdate()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(yatay, 0, dikey);
        physic.velocity = movement * speed;
        Vector3 position = new Vector3(
            Mathf.Clamp(physic.position.x, boundry.xMin, boundry.xMax),
            1.09f,
            Mathf.Clamp(physic.position.z,boundry.zMin,boundry.zMax)
            );
        physic.position = position;
        physic.rotation = Quaternion.Euler(0, 0, physic.velocity.x * -slope);
    }
}
