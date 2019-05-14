using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 1.0f;
    public float bulletLifetime = 5.0f;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rb.velocity = transform.TransformDirection(Vector3.forward) * bulletSpeed;
        Destroy(gameObject, bulletLifetime);
    }
}
