using Isopods.Interfaces;
using UnityEngine;
using Isopods.Constants;
using ENEMY = Isopods.Constants.ENEMY_CONST;
using PROJECTILE = Isopods.Constants.WEAPON_CONST.ENEMY_PROJECTILE_CONSTANTS;
using System.Collections;

public class EnemyBehavior : MonoBehaviour, IDamageable, ILaunchable
{
    public float rotationSpeed = 5.0f;
    private Transform target;

    [SerializeField]
    private float _health = ENEMY.DEFAULT_ENEMY_HEALTH;
    public float health { get { return _health; } private set { _health = value; } }

    public int ammo { get; set; }

    public float timeBetweenShots { get { return PROJECTILE.ENEMY_PROJECTILE_TIME_BETWEEN_SHOTS; } set { timeBetweenShots = value; } }

    public float reloadTime { get; set; }

    public bool reloading { get; set; }

    [SerializeField]
    private GameObject _projectile;
    public GameObject projectile { get { return _projectile; } }

    [SerializeField]
    private float _projectileSpeed = PROJECTILE.ENEMY_PROJECTILE_SPEED;
    public float projectileSpeed { get { return _projectileSpeed; } set { _projectileSpeed = value; } }

    private Vector2 direction;
    private Quaternion rotation;
    private float _shotTimeDelay = 0.0f;


    void Start ()
    { 
        target = GameObject.FindGameObjectWithTag(PLAYER_CONST.PLAYER_TAG).transform;
    }
	
	void Update ()
    {
        direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        if(Vector2.Distance(target.position, transform.position) <= 10.0f && _shotTimeDelay <= 0.0f)
        {
            Shoot();
            _shotTimeDelay = timeBetweenShots;
        }
        _shotTimeDelay -= Time.deltaTime;
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

    public void Shoot()
    { 
            var enemyProjectile = Instantiate(projectile, gameObject.transform.position, rotation);
            enemyProjectile.GetComponent<Rigidbody2D>().AddForce((target.position - transform.position) * projectileSpeed);
    }

    public IEnumerator Reload()
    {
        throw new System.NotImplementedException();
    }
}
