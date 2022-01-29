using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool inRange;
    public GameObject currentObject;
    private void Update()
    {

        if (inRange && Input.GetKey(KeyCode.E))
        {

            switch (FindObjectOfType<GameStateManager>().currentSceneState)
            {
                case GameStateManager.GameScene.TRASHYARD:
                    FindObjectOfType<InventoryManager>().Pickup(currentObject);
                    Debug.Log("Item picked up Play pickup animation");
                    break;
                case GameStateManager.GameScene.IMAGINATION:
                    currentObject.transform.position = transform.position + new Vector3(0, 1, 0);
                    break;

            }

            inRange = false;

        }

      

    }
    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("pickup"))
        {
            currentObject = other.gameObject;
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("pickup"))
        {
            currentObject = null;
            inRange = false;
        }
    }
}
