using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;

    public float playerMoveAcce;
    public float playerMoveSpeedMax;

    private void PlayerControll()
    {
        PlayerMove();
    }
    private void PlayerMove()
    {
        PlayerAddSpeed();
    }
    private void PlayerAddSpeed()
    {
        if (Input.GetAxis("leftStickX") != 0 || Input.GetAxis("leftStickY") != 0)
        {
            //rb.velocity = Vector3.zero;
            rb.velocity = new Vector3(rb.velocity.x + playerMoveAcce * Input.GetAxis("leftStickX"), 0, rb.velocity.z - playerMoveAcce * Input.GetAxis("leftStickY"));
        }
      
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControll();
    }
}
