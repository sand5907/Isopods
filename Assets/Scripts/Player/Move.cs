using Isopods.Constants;
using Isopods.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using PLAYER = Isopods.Constants.PLAYER_CONST;

public class Move : MonoBehaviour, IDamageable
{
    //Movement speed
    public float topSpeed = 10f;

    private bool playerOnGround = false;
    private bool playerOnSnail = false;
    public float _health = PLAYER.MAX_HEALTH;
    private bool heal = true;

    public GameObject Canvas_Text;
    private Text message;

    public float health { get { return _health; } set { _health = value; } }

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
        message = Canvas_Text.GetComponent<Text>();
        message.text = health.ToString();

        //get move direction
        float move = Input.GetAxis("Horizontal");

        //Add velocity to move controls
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * PLAYER.TOP_SPEED, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void Update()
    {

        if (heal && Input.GetKeyDown(KeyCode.E))
        {
            health = 100;
            heal = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);

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

    public void TakeDamage(float damageTaken)
    {
        damageTaken = (damageTaken <= 0.0f) ? 0.0f : damageTaken;
        health -= damageTaken;

        if (health <= 0.0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}