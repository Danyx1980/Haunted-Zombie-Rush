using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Animator animator; 
    Rigidbody rigidBody;

    bool jump;

    [SerializeField]
    float jumpForce; 

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();

        jump = false;

        jumpForce = 100f; 
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("Jump");
            rigidBody.useGravity = true;
            jump = true; 
        }
	}

    private void FixedUpdate()
    {
        if(jump == true)
        {
            jump = false;
            rigidBody.velocity = new Vector2(0, 0); 
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse); 
        }
    }
}
