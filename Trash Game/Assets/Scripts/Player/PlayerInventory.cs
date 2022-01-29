using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool inRange;
    public GameObject currentObject;
    public bool pickedUp;

    private void Start()
    {
        pickedUp = false;
    }
    private void Update()
    {

        switch (FindObjectOfType<GameStateManager>().currentState)
        {
            case GameStateManager.GameState.PLAYING:

                if (inRange && Input.GetKey(KeyCode.E))
                {

                    switch (FindObjectOfType<GameStateManager>().currentSceneState)
                    {
                        case GameStateManager.GameScene.TRASHYARD:
                            FindObjectOfType<InventoryManager>().Pickup(currentObject);
                            Debug.Log("Item picked up Play pickup animation");
                            break;
                        case GameStateManager.GameScene.IMAGINATION:
                            currentObject.transform.position = transform.position + new Vector3(0, 2, 0);
                            pickedUp = true;
                            break;
                            
                    }

                    inRange = false;

                }
                else if (pickedUp && Input.GetKeyDown(KeyCode.E))
                {
                    currentObject.transform.position = transform.position + new Vector3(2, 2, 0);
                    pickedUp = false;
                    currentObject.GetComponent<Rigidbody>().freezeRotation = false;
                    currentObject.GetComponent<Rigidbody>().isKinematic = false;
                    inRange = false;
                }

                if (pickedUp)
                {
                    currentObject.GetComponent<Rigidbody>().isKinematic = true;
                    currentObject.transform.position = transform.position + new Vector3(0, 2, 0);
                    inRange = false;
                }
                break;
            case GameStateManager.GameState.DIALOG:
                break;


        }


      

    }
    private void OnTriggerEnter(Collider other)
    {
        switch(pickedUp)
        {
            case true:
                break;

            case false:
                if (other.CompareTag("pickup"))
                {
                    currentObject = other.gameObject;
                    inRange = true;
                }
                break;

        }
       
    }

    private void OnTriggerExit(Collider other)
    {

        switch (pickedUp)
        {
            case false:
                if (other.CompareTag("pickup"))
                {
                    currentObject = null;
                    inRange = false;
                }
                break;
            case true:
                
                break;
        }
        
    }
}
