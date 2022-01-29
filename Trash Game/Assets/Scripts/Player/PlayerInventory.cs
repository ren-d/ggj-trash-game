using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool inRange;
    public List<GameObject> inventory;
    public GameObject currentObject;
    private void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            inventory.Add(currentObject);
            Debug.Log("Item picked up");
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
