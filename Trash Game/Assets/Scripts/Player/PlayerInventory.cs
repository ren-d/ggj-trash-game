using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool inRange;
    public GameObject currentObject;
    private void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<InventoryManager>().Pickup(currentObject);
            Debug.Log("Item picked up Play pickup animation");
           
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
}
