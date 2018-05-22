using Isopods.Interfaces;
using UnityEngine;
using Isopods.Constants;

public class EnemyBehavior : MonoBehaviour, IDamageable
{
    public float rotationSpeed = 5.0f;
    private Transform target;
    public float health { get; set; }

    
    // Use this for initialization
    void Start ()
    {
        health = ENEMY_CONST.DEFAULT_ENEMY_HEALTH;
        target = GameObject.FindGameObjectWithTag(PLAYER_CONST.PLAYER_TAG).transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    public void TakeDamage(float damageTaken)
    {
        damageTaken = (damageTaken <= 0.0f) ? 0.0f : damageTaken;
        health -= damageTaken;

        if (health <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
