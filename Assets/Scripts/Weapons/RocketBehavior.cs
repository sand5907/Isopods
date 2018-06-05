using Isopods.Interfaces;
using Isopods.Constants;
using ROCKET = Isopods.Constants.WEAPON_CONST.ROCKET_CONSTANTS;
using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
    private float _timeToLive = ROCKET.ROCKET_TIME_TO_LIVE;

    void Update()
    {
        _timeToLive -= Time.deltaTime;
        if (_timeToLive <= 0.0f)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<IDamageable>() != null && other.gameObject.tag != PLAYER_CONST.PLAYER_TAG)
        {
            Destroy(gameObject);
            other.GetComponent<IDamageable>().TakeDamage(ROCKET.DEFAULT_ROCKET_DAMAGE);
        }
    }
}
