using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

using System;
using System.Threading;

public class bots : MonoBehaviour
{
	public Transform player;

	public GameObject Bullet_Emitter;
 
    public GameObject Bullet;
 
    public float Bullet_Forward_Force;

    int counter = 0;

    void Start()
    {
        
    }

    void Update()
    {	
    	if(Vector3.Distance(player.position, this.transform.position)<50)
    	{
    		Vector3 direction = player.position - this.transform.position;
    		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction),0.1f);
            if(direction.magnitude > 25)
            {
                this.transform.Translate(0,0,0.15f);
            }
            else{
              counter+=1;
              if (counter%50 == 1){
              shootWithIntervals();
          		}
          	counter+=1;
            }
        } 
    }

    void shootWithIntervals(){

    	 	GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Bullet,Bullet_Emitter.transform.position,Bullet_Emitter.transform.rotation) as GameObject;
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
            Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);
            Destroy(Temporary_Bullet_Handler, 0.1f);
    }

    void OnTriggerEnter(Collider other){
            Debug.Log(other.gameObject.name);
            Destroy(this.gameObject);
        } 
}