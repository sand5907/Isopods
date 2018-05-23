using Isopods.Interfaces;
using WEAPON = Isopods.Constants.WEAPON_CONST;
using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<IDamageable>() != null)
        {
            Destroy(gameObject);
            other.GetComponent<IDamageable>().TakeDamage(WEAPON.DEFAULT_ROCKET_DAMAGE);
        }
    }
}
