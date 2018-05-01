using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Move : MonoBehaviour
{
    //Movement speed
    public float topSpeed = 10f; 

    //direction
    public bool facingRight = true; 

    //Not grounded
    bool grounded = false;

    public bool jumped = false;

    //Checks if player is on ground
    public Transform groundCheck; 

    //how big circle is to check if grounded
    float groundRadius = 0.4f;

    //Force of jump
    public float jumpForce = 700f;

    //What Layer is ground
    public LayerMask whatIsGround;


    private void FixedUpdate() //Physics is fixed
    {
        //is the player grounded?
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        //get move direction
        float move = Input.GetAxis("Horizontal");

        //Add velocity to move controls
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }

    private void Update()
    {
        jumped = false;
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            jumped = true;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;

        //theScale.x *= -1;

        transform.localScale = theScale;
    }
}
