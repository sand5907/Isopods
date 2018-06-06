using Isopods.Interfaces;
using Isopods.Constants;
using UnityEngine;
using PROJECTILE = Isopods.Constants.WEAPON_CONST.ENEMY_PROJECTILE_CONSTANTS;

public class EnemyProjectileBehavior : MonoBehaviour
{

    private float _timeToLive = PROJECTILE.TIME_TO_LIVE;
    
    // Update is called once per frame
    void Update()
    {
        _timeToLive -= Time.deltaTime;
        if (_timeToLive <= 0.0f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IDamageable>() != null && collision.gameObject.tag == PLAYER_CONST.PLAYER_TAG)
        {
            Destroy(gameObject);
            collision.GetComponent<IDamageable>().TakeDamage(PROJECTILE.ENEMY_PROJECTILE_DAMAGE);
        }
    }
}
