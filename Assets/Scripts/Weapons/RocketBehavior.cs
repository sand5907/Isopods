using Isopods.Interfaces;
using WEAPON = Isopods.Constants.WEAPON_CONST;
using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
    private float _timeToLive = WEAPON.ROCKET_TIME_TO_LIVE;

    void Update()
    {
        _timeToLive -= Time.deltaTime;
        if (_timeToLive <= 0.0f)
            Destroy(gameObject);
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
