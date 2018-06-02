using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    //Movement speed
    public float topSpeed = 10f;

    //direction
    public bool facingRight = true;

    //Not grounded
    private bool grounded = false;
    private bool snailed = false;

    //Checks if player is on ground
    public Transform groundCheck;

    //how big circle is to check if grounded
    private float groundRadius = 0.4f;

    //Force of jump
    public float jumpForce = 700f;

    //What Layer is ground
    public LayerMask whatIsGround;
    public LayerMask whatIsSnail;

    public string PlayerCollidingTag;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(PlayerCollidingTag))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void Start()
    {
        //Ignores below water layer
        Physics2D.IgnoreLayerCollision(10, 9);
    }

    private void FixedUpdate() //Physics is fixed
    {
        //is the player grounded?
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        snailed = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsSnail);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            else if (snailed)
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce * 1.6f));
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }
}