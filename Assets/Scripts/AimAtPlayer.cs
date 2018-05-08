﻿
using UnityEngine;

public class AimAtPlayer : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform target;

    private void Update()
    {
        //Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}

