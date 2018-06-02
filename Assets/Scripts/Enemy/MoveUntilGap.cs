using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUntilGap : MonoBehaviour
{

    //Movement speed
    public float speed = -2f;

    //Not grounded
    private bool grounded = false;

    //Checks if player is on ground
    public Transform groundCheck;

    //how big circle is to check if grounded
    private float groundRadius = 0.05f;

    //What Layer is ground
    public LayerMask whatIsGround;


    private void FixedUpdate() //Physics is fixed
    {
        //is the player grounded?
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);


        //Add velocity to move controls

        if (grounded)
        {
            if (GetComponent<Rigidbody2D>().velocity.x == 0)
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1f);
          
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            speed = -speed;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

    }


}
