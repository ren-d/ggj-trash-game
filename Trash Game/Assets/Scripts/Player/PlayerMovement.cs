using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour { 

    [Header("Components")]
    Rigidbody m_Rigidbody;

    [Header("MovementVariables")]
    Vector3 moveDirection;
    public float movementSpeed;
    public float jumpForce;


    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
    }

    private void FixedUpdate()
    {
        m_Rigidbody.velocity = moveDirection.normalized * movementSpeed;
    }

    private void MovementInput()
    {
        // Horizontal and Vertical movement
        float xAxisInput = Input.GetAxisRaw("Horizontal");
        float zAxisInput = Input.GetAxisRaw("Vertical");

        // Jump check
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Rigidbody.AddForce(xAxisInput, jumpForce, zAxisInput);
            print("works!");
        }

        moveDirection = new Vector3(xAxisInput, 0.0f, zAxisInput);
    }
}
