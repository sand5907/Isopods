using UnityEngine;

public class MoveUntilGap : MonoBehaviour
{

    //Movement speed
    public float speed = -2f;

    //Not grounded
    public bool grounded = false;

    public void notOnGround()
    {
        grounded = false;
    }

    private void FixedUpdate() //Physics is fixed
    {
 
        if (grounded)
        {
            if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) <.05f)
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            speed = -speed;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            grounded = true;
        }

    }


}
