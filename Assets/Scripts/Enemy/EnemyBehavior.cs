﻿using Isopods.Interfaces;
using UnityEngine;
using Isopods.Constants;
using ENEMY = Isopods.Constants.ENEMY_CONST;

public class EnemyBehavior : MonoBehaviour, IDamageable
{
    public float rotationSpeed = 5.0f;
    private Transform target;

    [SerializeField]
    private float _health;
    public float health { get { return _health; } private set { _health = value; } }

    
    // Use this for initialization
    void Start ()
    {
        health = ENEMY.DEFAULT_ENEMY_HEALTH;
        target = GameObject.FindGameObjectWithTag(PLAYER_CONST.PLAYER_TAG).transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        Debug.Log(GameController.score);
    }

    public void TakeDamage(float damageTaken)
    {
        damageTaken = (damageTaken <= 0.0f) ? 0.0f : damageTaken;
        health -= damageTaken;

        if (health <= 0.0f)
        {
            Destroy(gameObject);
            GameController.score += 50;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IDamageable>() != null)
        {
            collision.gameObject.GetComponent<IDamageable>().TakeDamage(ENEMY.DEFAULT_COLLISION_DAMAGE);
        }
    }
}
