using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]float speed = 1.0f;
    [SerializeField] float jumpForce = 1.0f;
    Vector3 jump = new Vector3(0, 1, 0);
    public bool isGrounded;
    GroundCheck groundCheck;
    public Rigidbody rigidbody;
    public Vector3 movementDirection;
    private Animator anim;

    void Start()
    {
        anim = transform.GetChild(1).gameObject.GetComponent<Animator>();
        groundCheck = transform.GetChild(0).gameObject.GetComponent<GroundCheck>();
        switch(FindObjectOfType<GameStateManager>().currentSceneState)
        {
            case GameStateManager.GameScene.TRASHYARD:
                transform.position = FindObjectOfType<GameStateManager>().playerScrapPos;
                break;
            case GameStateManager.GameScene.IMAGINATION:
                transform.position = new Vector3(0, 100, 0);
                break;
        }
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
                MovePlayer();
                break;

            case GameStateManager.GameState.DIALOG:
 
                break;

            case GameStateManager.GameState.MENU:

                break;

            case GameStateManager.GameState.PAUSED:

                break;
        }


        switch (FindObjectOfType<GameStateManager>().currentSceneState)
        {
            case GameStateManager.GameScene.TRASHYARD:
                if(Input.GetKey(KeyCode.F))
                {
                    FindObjectOfType<GameStateManager>().playerScrapPos = transform.position;
                    
                    FindObjectOfType<GameStateManager>().currentSceneState = GameStateManager.GameScene.IMAGINATION;
                    Debug.Log("NO");
                    SceneManager.LoadScene(3);
                    
                }
                break;

            case GameStateManager.GameScene.IMAGINATION:
                if (Input.GetKey(KeyCode.F))
                {
                    Debug.Log("YES");
                    FindObjectOfType<InventoryManager>().saveValues();
                    transform.position = FindObjectOfType<GameStateManager>().playerScrapPos;
                    FindObjectOfType<GameStateManager>().currentSceneState = GameStateManager.GameScene.TRASHYARD;
                    SceneManager.LoadScene(2);
                }
                break;
        }

        GroundCheck();
    }

    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(movementDirection.normalized * speed * Time.deltaTime);
        rigidbody.velocity = new Vector3(moveVector.x, rigidbody.velocity.y, moveVector.z);

        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            
            transform.GetChild(0).gameObject.GetComponent<GroundCheck>();
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            
        }
    }



    private void GroundCheck()
    {
        isGrounded = groundCheck.isGrounded;

    }
}
