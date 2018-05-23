using Isopods.Interfaces;
using System.Collections;
using UnityEngine;

public class Bazooka : MonoBehaviour, ILaunchable
{
    [Range(1.0f, 20.0f)]
    public float bazookaRotationSpeed = 5.0f;

    [Range(1.0f, 1000.0f)]
    [SerializeField]
    private float _projectileSpeed;
    public float projectileSpeed { get { return _projectileSpeed; } set { _projectileSpeed = value; } }

    [SerializeField]
    private GameObject _projectile;
    public GameObject projectile { get { return _projectile; } }

    [SerializeField]
    private int _ammo = 5;
    public int ammo { get { return _ammo; } set { _ammo = value; } }

    [Range (0.0f, 1.5f)]
    [SerializeField]
    private float _timeBetweenShots;
    public float timeBetweenShots { get { return _timeBetweenShots; } set { _timeBetweenShots = value; } }

    private float _shotTimeDelay = 0.0f;

    private Vector2 direction;
    private Quaternion rotation;
    
	void Update ()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, bazookaRotationSpeed * Time.deltaTime);
        

        if(Input.GetKeyDown(KeyCode.Mouse0) && _shotTimeDelay <= 0.0f)
        {
            Shoot();
            _shotTimeDelay += _timeBetweenShots;
        }

        _shotTimeDelay -= Time.deltaTime;
    }
    
    public void Shoot()
    {
        var rocket = Instantiate(projectile, gameObject.GetComponentInChildren<Transform>().position, rotation);
        rocket.transform.Rotate(0, 0, 90);
        rocket.AddComponent<Rigidbody2D>().AddForce(direction * projectileSpeed);
    }
}
