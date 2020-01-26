using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilOtto : MonoBehaviour
{
   public Transform player;

   void Start()
    {
        
    }

    void Update()
    {	
    	if(Vector3.Distance(player.position, this.transform.position)<40)
    	{
    		Vector3 direction = player.position - this.transform.position;
    		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction),0.1f);
            this.transform.Translate(0,0,0.15f);
        } 
    }
}
