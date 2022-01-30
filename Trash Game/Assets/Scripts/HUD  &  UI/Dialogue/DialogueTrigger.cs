using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue[] pickupDialogue;

    public bool inRange = false;



    public GameObject[] needItem;

    bool found = false;
    int hasItem = 0;




    public void TriggerDialogue()
    {
        if(hasItem == 0)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

        if(hasItem > 0)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(pickupDialogue[hasItem - 1]);
            FindObjectOfType<PlayerInventory>().currentObject.transform.position = transform.position + new Vector3(0, 2, 0);
            FindObjectOfType<PlayerInventory>().currentObject.GetComponent<BoxCollider>().enabled = false;
            FindObjectOfType<PlayerInventory>().currentObject.GetComponent<Rigidbody>().isKinematic = true;
            hasItem++;
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

           if (hasItem < needItem.Length)
           {
               if (other.gameObject.tag == "Player")
               {
                   switch (FindObjectOfType<PlayerInventory>().pickedUp)
                   {
                       case true:

                               if (needItem[hasItem].name == FindObjectOfType<PlayerInventory>().currentObject.name)
                               {
                                    hasItem++;
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
