using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LEVEL = Isopods.Constants.LEVEL_CONST;

public class Ignore_Collision : MonoBehaviour {


    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == LEVEL.WATER_TAG)
            Physics2D.IgnoreCollision(collider.collider, GetComponent<Collider2D>());
    }
}
