using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speedMovement = 5f;
    [SerializeField] float rotationSpeed = 100f;

    [SerializeField] float x;
    [SerializeField] float y;

    // Animations
    private Animator animator;

    // Cameras
    [SerializeField] Camera camBack;
    [SerializeField] Camera camFront;

    // Jump
    [SerializeField] Rigidbody rb;
    [SerializeField] float jumpForce;
    [SerializeField] bool touchingGround;
    [SerializeField] bool canJump;
    [SerializeField] bool jumped;

    // Start is called before the first frame update
    void Start()
    {
        // Animations
        animator = GetComponent<Animator>();

        // Cameras
        camBack.enabled = true;
        camFront.enabled = false;

        // Jump
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);

        // Cameras
        ChangeCamera();

        // Jump
        Jump();
    }

    private void FixedUpdate()
    {
        //Movimiento
        transform.Rotate(0, x * Time.fixedDeltaTime * rotationSpeed, 0);
        if (y < 0f)
        {
            transform.Translate(0, 0, y * Time.fixedDeltaTime * 1.3f);
        }
        else
        {
            transform.Translate(0, 0, y * Time.fixedDeltaTime * speedMovement);
        }
        
    }

    private void Jump()
    {
        if(canJump)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("Jumped", true);
                jumped = true;

                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);                
            }
        }
    }

    private void ChangeCamera()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            camBack.enabled = false;
            camFront.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camBack.enabled = true;
            camFront.enabled = false;
        }
    }
}
