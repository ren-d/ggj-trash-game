using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public struct inventoryItem
{
    public GameObject item;
    public GameObject item1;
    public bool isCollected;
    public Vector3 imaginationPos;
    public Vector3 scrapyardPos;

    public bool spawned, iSaved, sSaved;
    public int x;
}

public class InventoryManager : MonoBehaviour
{
    public inventoryItem[] inventory;

    public void saveValues()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            
            switch (FindObjectOfType<GameStateManager>().currentSceneState)
            {
                case GameStateManager.GameScene.IMAGINATION:
                    Debug.Log("PLEASE");
                    if (inventory[i].isCollected && inventory[i].spawned)
                    {
                        inventory[i].imaginationPos = inventory[i].item1.transform.position;

                        inventory[i].iSaved = true;
                    }
                    break;
                case GameStateManager.GameScene.TRASHYARD:

                    break;
            }
        }
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

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.F))
        {
            saveValues();
        }

        for (int i = 0; i < inventory.Length; i++)
        {
            
            switch (FindObjectOfType<GameStateManager>().currentSceneState)
            {
                case GameStateManager.GameScene.IMAGINATION:
                    if(inventory[i].isCollected)
                    {
                        if(!inventory[i].spawned && !inventory[i].iSaved)
                        {
                            
                            inventory[i].item1 = Instantiate<GameObject>(inventory[i].item, GameObject.Find("SpawnPoint").transform);
                            inventory[i].spawned = true;
                        }else if(!inventory[i].spawned && inventory[i].iSaved)
                        {
                            inventory[i].item1 = Instantiate<GameObject>(inventory[i].item, GameObject.Find("SpawnPoint").transform);
                            inventory[i].item1.transform.position = inventory[i].imaginationPos;
                            inventory[i].spawned = true;
                        }
                       


                    }
                    break;
                case GameStateManager.GameScene.TRASHYARD:
                    inventory[i].spawned = false;
                    break;
            }

           

        }
    }




}
