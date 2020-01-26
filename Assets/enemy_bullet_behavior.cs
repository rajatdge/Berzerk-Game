using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_bullet_behavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "ToonSoldier_demo"){
        	Destroy(collision.gameObject);
        	SceneManager.LoadScene("GameOverScreen");
        }

        if(collision.gameObject.name == "GruntHP" || collision.gameObject.name == "GruntHP (1)" || collision.gameObject.name == "GruntHP (2)" || collision.gameObject.name == "GruntHP (3)"){
        	Destroy(collision.gameObject);
        }
    }
}