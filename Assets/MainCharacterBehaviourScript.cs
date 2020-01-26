using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCharacterBehaviourScript : MonoBehaviour
{
	float playerSpeed = 15;
	float playerRotationSpeed = 80;
	float playerRotation = 0f;
	float gravity = 8;

	public GameObject bomb; 

	Vector3 moveDir = Vector3.zero;

	CharacterController controller;
	Animator anim;

    // Start is called before the first frame update
    void Start()
    {
    	controller = GetComponent<CharacterController>();
    	anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
    	if (controller.isGrounded)
    	{
    		if(Input.GetKey(KeyCode.W))
    		{
    			anim.SetInteger("condition", 1);
    			moveDir = new Vector3(0,0,1);
    			moveDir*= playerSpeed;
    			moveDir = transform.TransformDirection(moveDir);
    		}
    		if(Input.GetKeyUp(KeyCode.W))
    		{
    			anim.SetInteger("condition", 0);
    			moveDir = new Vector3(0,0,0);

    		}
    		if(Input.GetKey(KeyCode.S))
    		{
    			anim.SetInteger("condition", 1);
    			moveDir = new Vector3(0,0,-1);
    			moveDir*= playerSpeed;
    			moveDir = transform.TransformDirection(moveDir);
    		}

    	}
    	playerRotation += Input.GetAxis("Horizontal") * playerRotationSpeed * Time.deltaTime;
    	transform.eulerAngles = new Vector3(0,playerRotation,0); 

    	moveDir.y -= gravity * Time.deltaTime;
    	controller.Move(moveDir * Time.deltaTime);

    	processInput();
        
    }

    void processInput()
    {
    	if(controller.isGrounded)
    	{
    		if (Input.GetMouseButtonDown(0))
    		{
    			Attack();
    		}
    	}
    }

    void Attack()
    {
    	anim.SetInteger("condition", 2);
    }

    void OnTriggerEnter(Collider other){
            Destroy(this.gameObject);
            GameObject b = Instantiate(bomb);
            b.transform.position = this.transform.position;
            SceneManager.LoadScene("GameOverScreen");
            Debug.Log("Game Over");
        } 
}
