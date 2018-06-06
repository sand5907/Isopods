using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Flip : MonoBehaviour {

    //direction
    private bool playerFacingRight = true;

    // Update is called once per frame
    void Update () {
        //get move direction
        float move = Input.GetAxis("Horizontal");

        if (move > 0 && !playerFacingRight)
            Flip();
        else if (move < 0 && playerFacingRight)
            Flip();
    }

    void Flip()
    {
        playerFacingRight = !playerFacingRight;
        Vector3 theScale = transform.localScale;

        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
