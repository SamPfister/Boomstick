using System.Collections;
using System.Collections.Generic;
//using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Credit to Brackeys for the code: https://www.youtube.com/watch?v=_QajrabyTJc&t=115s

    public float gravity = -10f;

    public float speed = 30f;

    public float jumpHeight = 3f;

    public CharacterController controller;

    public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    private const int maxJumps = 2;

    private int currentJump = 0;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            currentJump = 0;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            currentJump = 1;
            velocity.y = Mathf.Sqrt(-2f * gravity * jumpHeight);
           
        }
        else if (Input.GetButtonDown("Jump") && (currentJump < maxJumps))
        {
            velocity.y = Mathf.Sqrt(-2f * gravity * jumpHeight);
            currentJump++;

        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
