using Isopods.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

using PLAYER = Isopods.Constants.PLAYER_CONST;

public class Move : MonoBehaviour
{
    //direction
    private bool playerFacingRight = true;
    //Movement speed
    public float topSpeed = 10f;

    //direction
    public bool facingRight = true;

    private bool playerOnGround = false;
    private bool playerOnSnail = false;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(LEVEL_CONST.END_LEVEL_FLAG_TAG))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {

        if (collider.gameObject.tag == LEVEL_CONST.GROUND_TAG)
        {
            playerOnGround = true;
            playerOnSnail = false;
        }
        else if (collider.gameObject.tag == ENEMY_CONST.SNAIL_TAG)
        {
            playerOnGround = false;
            playerOnSnail = true;
        }
    }

    private void FixedUpdate() //Physics is fixed
    {
        //get move direction
        float move = Input.GetAxis("Horizontal");

        //Add velocity to move controls
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * PLAYER.TOP_SPEED, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !playerFacingRight)
            Flip();
        else if (move < 0 && playerFacingRight)
            Flip();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerOnGround)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, PLAYER.JUMP_FORCE));
                playerOnGround = false;
            }
            else if (playerOnSnail)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, PLAYER.JUMP_FORCE * PLAYER.SNAIL_JUMP_BONUS));
                playerOnSnail = false;
            }
        }
    }

    void Flip()
    {
        playerFacingRight = !playerFacingRight;
        Vector3 theScale = transform.localScale;

        theScale.x *= -1;
        transform.localScale = theScale;
    }


}