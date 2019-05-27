using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IPulledNecrosis
{
    public float upForce = 1f;
    public float sideForce = .1f;

    public Rigidbody rigid;
    public void onObjectSpawn(){
        float xForce = Random.Range(-sideForce, 0); 
        float yForce = Random.Range(-upForce / 2f, 0); 
        float zForce = Random.Range(-sideForce, 0);

        Vector3 force = new Vector3(xForce, yForce, zForce);

        rigid.velocity = force;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            gameObject.SetActive(false);
        }
    }
}
