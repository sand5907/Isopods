using UnityEngine;

public class Bazooka : MonoBehaviour
{
    [Range(1.0f, 20.0f)]
    public float bazookaRotationSpeed = 5.0f;

    [Range(1.0f, 1000.0f)]
    public float projectileSpeed = 1000.0f;

    public GameObject projectile;
    public int ammo = 5;
    

    private Vector2 direction;
    private Quaternion rotation;
    
	
	// Update is called once per frame
	void Update ()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, bazookaRotationSpeed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
    
    public void Shoot()
    {
        var rocket = Instantiate(projectile, gameObject.GetComponentInChildren<Transform>().position, rotation);
        rocket.transform.Rotate(0, 0, 90);
        rocket.AddComponent<Rigidbody2D>().AddForce(direction * projectileSpeed);
    }
}
