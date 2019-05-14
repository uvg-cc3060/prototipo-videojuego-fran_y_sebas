using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float shootingCooldown = 0.5f;
    public Transform bulletPoint;
    public GameObject bulletPrefab;
    public Camera mainCamera;

    private float _curCooldown;
    private bool _shot;

    private void Start()
    {
        _curCooldown = shootingCooldown;
    }

    private void Update()
    {
        // Debug bullet direction
        Debug.DrawRay(bulletPoint.position, transform.forward * 5.0f, Color.red);
        
        if (Input.GetMouseButton(0) && !_shot)
        {
            _curCooldown = shootingCooldown;
            _shot = true;
            ShootBullet();
        }

        if (_shot)
        {
            _curCooldown -= Time.deltaTime;
        }

        if (_curCooldown < 0f)
        {
            _curCooldown = shootingCooldown;
            _shot = false;
        }
    }

    private void ShootBullet()
    {
        Vector3 r = transform.rotation.eulerAngles;
        Quaternion rot = Quaternion.Euler(mainCamera.transform.rotation.eulerAngles.x * 2f, r.y, r.z);
        GameObject go = Instantiate(bulletPrefab, bulletPoint.position, rot);
    }
}
