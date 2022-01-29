using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct inventoryItem
{
    public GameObject item;
    public bool isCollected;
}

public class InventoryManager : MonoBehaviour
{
    public inventoryItem[] inventory;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void Pickup(GameObject item)
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            Debug.Log(i);
            if(inventory[i].item.name == item.name)
            {
                inventory[i].isCollected = true;
            }
        }
        Destroy(item);
        
    }


}
