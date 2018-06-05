using Isopods.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollisionBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<IDamageable>() != null)
        {
            collision.gameObject.GetComponent<IDamageable>().TakeDamage(collision.gameObject.GetComponent<IDamageable>().health);
        }
    }
}
