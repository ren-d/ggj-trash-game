using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]float speed = 1.0f;
    [SerializeField] float jumpForce = 1.0f;
    Vector3 jump = new Vector3(0, 1, 0);
    public bool isGrounded;
    Rigidbody rigidbody;
    public Vector3 movementDirection;


    void Start()
    {
        isGrounded = false;
        rigidbody = this.GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0f, -30f, 0f);
    }


    void FixedUpdate()
    {
      

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector3(horizontal , 0, vertical );

        switch (FindObjectOfType<GameStateManager>().currentState)
        {
            case GameStateManager.GameState.PLAYING:
                Time.timeScale = 1;
                MovePlayer();
                break;

            case GameStateManager.GameState.DIALOG:
                Time.timeScale = 0;
                break;

            case GameStateManager.GameState.MENU:
                    
                break;

            case GameStateManager.GameState.PAUSED:
                Time.timeScale = 0;
                break;
        }


    }

    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(movementDirection.normalized * speed * Time.deltaTime);
        rigidbody.velocity = new Vector3(moveVector.x, rigidbody.velocity.y, moveVector.z);

        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.CompareTag("Ground"))
        {
            case true:
                isGrounded = true;
                break;
            case false:
                break;
        }
        
    }
}
