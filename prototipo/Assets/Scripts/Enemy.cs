using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class Enemy : MonoBehaviour, IPulledNecrosis
{
    public float upForce = 1f;
    public float sideForce = .1f;

    public GameObject targetFollow;

    private float nextExec = 0.0f;
    public float period = 0.1f;

    private bool active;
    private bool alive;

    private int count;
    

    public Rigidbody rigid;
    public void onObjectSpawn(){
        float xForce = Random.Range(-sideForce, 0); 
        float yForce = Random.Range(-upForce / 2f, 0); 
        float zForce = Random.Range(-sideForce, 0);

        Vector3 force = new Vector3(xForce, yForce, zForce);

        rigid.velocity = force;
        
        active = false;
        alive = true;

        
        targetFollow = GameObject.Find("ThirdPersonController");
        //disque vector hacia abajo
        //local_up = local_up-ground; 
    }

     
    void FixedUpdate(){
        //obtenemos posiciones a cada rato
        
      // Debug.Log(diff);


        float dist = Vector3.Distance(rigid.transform.position, targetFollow.transform.position);

        if(dist<12 && alive==true){
            active = true;
            follow();
            //Debug.Log("jajajjas;ldaka'");
        } else{
            active = false;
        }
      
        
    }

    private void fixRotation(){
        Vector3 relativePos = rigid.position;

        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        rigid.rotation = rotation;

    }

    private void follow(){
        
            //Debug.Log(dist);
            rigid.transform.LookAt(targetFollow.transform);
            rigid.transform.position += transform.forward * 2.0f * Time.deltaTime;

        
        
    }
    
    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("PlayerBullet"))
        {
            gameObject.SetActive(false);
        }

        
    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.name == "Bullet(Clone)")
        {
            active = false;
            alive = false;
            Debug.Log("jaja");
            
        }

        if(col.gameObject.name == "Plane" || col.gameObject.name == "banqueta"){
            if (count<5 && active == false){
                fixRotation();
                count++;

            }
            
        }

       
    }
}
