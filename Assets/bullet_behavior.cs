using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_behavior : MonoBehaviour
{

	public GameObject bomb;
	public AudioClip clip;
	public AudioSource destroyAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
    	if (other.gameObject.name == "in-wall1" || other.gameObject.name == "in-wall2" || other.gameObject.name == "topwall" || other.gameObject.name == "leftmost wall" || other.gameObject.name == "rightmost wall" || other.gameObject.name == "bottom wall 1" || other.gameObject.name == "bottom wall 2" || other.gameObject.name == "middle wall 1" || other.gameObject.name == "middle wall 2" || other.gameObject.name == "GruntPBR"){
    		Destroy(this.gameObject);
    	}
    	else{
        Destroy(other.gameObject);
        Destroy(this.gameObject);
        GameObject b = Instantiate(bomb);
        b.transform.position = this.transform.position;
    	}
    }
}
