using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pMovement : MonoBehaviour
{
    [Header("Component references")]
    public Rigidbody playerRigidbody;

    [Header("Walking variables")]
    private float horizontal;
    private float vertical;
    private Vector3 walkDirection;
    public float walkSpeed = 5f;

    [Header("Jumping variables")]
    public bool isGrounded = false;
    public float jumpForce = 10f;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Checks player inputs
        HandleInput();
    }

    private void FixedUpdate()
    {
        Walk();

        Jump(); 
    }

    private void HandleInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        walkDirection = new Vector3(horizontal, 0, vertical);
    }

    private void Walk()
    {
        Vector3 moveVector = transform.TransformDirection(walkDirection.normalized * walkSpeed * Time.deltaTime);
        playerRigidbody.velocity = new Vector3(moveVector.z, playerRigidbody.velocity.y, moveVector.x);
    }

    private void Jump()
    {

    }
}
