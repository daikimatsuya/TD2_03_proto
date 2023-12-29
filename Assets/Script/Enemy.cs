using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameManagerScript gameManagerScript;
    Rigidbody rb;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wave")
        {
            rb.velocity= new Vector3( other.GetComponent<Rigidbody>().velocity.x/2, 0, other.GetComponent<Rigidbody>().velocity.z/2);
        }
        if(other.tag == "Wave2")
        {
            rb.velocity = new Vector3(other.GetComponent<Rigidbody>().velocity.x / 1.75f, 0, other.GetComponent<Rigidbody>().velocity.z / 1.75f);
        }
        if (other.tag == "Wave3")
        {
            rb.velocity = new Vector3(other.GetComponent<Rigidbody>().velocity.x / 1.5f, 0, other.GetComponent<Rigidbody>().velocity.z / 1.5f);
        }
     
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Circle")
        {

            gameManagerScript.CircleSizeUp(new Vector2((float)Math.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.z * rb.velocity.z)/2, (float)Math.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.z * rb.velocity.z)/2));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManagerScript = GameObject.FindWithTag("Manager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
