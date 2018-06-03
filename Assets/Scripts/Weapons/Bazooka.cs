using Isopods.Interfaces;
using System.Collections;
using UnityEngine;

using BAZOOKA = Isopods.Constants.WEAPON_CONST.BAZOOKA_CONSTANTS;


public class Bazooka : MonoBehaviour, ILaunchable
{
    [Range(1.0f, 20.0f)]
    public float bazookaRotationSpeed = BAZOOKA.ROTATION_SPEED;

    [Range(1.0f, 1000.0f)]
    [SerializeField]
    private float _projectileSpeed = BAZOOKA.PROJECTILE_SPEED;
    public float projectileSpeed { get { return _projectileSpeed; } set { _projectileSpeed = value; } }

    [SerializeField]
    private GameObject _projectile;
    public GameObject projectile { get { return _projectile; } }

    [SerializeField]
    private int _ammo = 5;
    public int ammo { get { return _ammo; } set { _ammo = value; } }

    [Range(0.0f, 1.5f)]
    [SerializeField]
    private float _timeBetweenShots;
    public float timeBetweenShots { get { return _timeBetweenShots; } set { _timeBetweenShots = value; } }

    private float _reloadTime = BAZOOKA.RELOAD_TIME;
    public float reloadTime { get { return _reloadTime; } }

    private bool _reloading = false;
    public bool reloading { get { return _reloading; } }

    private float _shotTimeDelay = 0.0f;

    private Vector2 direction;
    private Quaternion rotation;
    
    void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, bazookaRotationSpeed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Mouse0) && _shotTimeDelay <= 0.0f)
        {
            if (!reloading)
                Shoot();

            _shotTimeDelay += _timeBetweenShots;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

        _shotTimeDelay -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (_ammo > 0)
        {
            var rocket = Instantiate(projectile, gameObject.GetComponentInChildren<Transform>().position, rotation);
            rocket.transform.Rotate(0, 0, 90);
            rocket.AddComponent<Rigidbody2D>().AddForce(direction * projectileSpeed);
            _ammo -= 1;
        }
        else
        {
            StartCoroutine(Reload());
        }
    }

    public IEnumerator Reload()
    {
        _reloading = true;
        yield return new WaitForSeconds(reloadTime);
        _ammo = BAZOOKA.MAX_AMMO;
        _reloading = false;
    }
}