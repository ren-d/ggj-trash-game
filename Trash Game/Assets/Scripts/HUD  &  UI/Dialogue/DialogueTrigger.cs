using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue pickupDialogue;

    public bool inRange = false;
    public GameObject needItem;

    bool found = false;
    bool hasItem = false;

    public void TriggerDialogue()
    {
        switch(found)
        {
            case true:
                FindObjectOfType<DialogueManager>().StartDialogue(pickupDialogue);
                FindObjectOfType<PlayerInventory>().currentObject.transform.position = transform.position + new Vector3(0, 2, 0);
                hasItem = true;
                break;

            case false:
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    
                break;
        }
       
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.E) && inRange)
        {
            TriggerDialogue();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(!hasItem)
        {
            if (other.name == "Player")
            {
                switch (FindObjectOfType<PlayerInventory>().pickedUp)
                {
                    case true:
                        if (needItem.name == FindObjectOfType<PlayerInventory>().currentObject.name)
                        {
                            found = true;
                        }
                        break;
                    case false:

                        break;
                }
                inRange = true;

            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("player exit");
            inRange = false;
        }
    }
}
