using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue pickupDialogue;

    public BoxCollider npcTriggerbox;
    public bool inRange = false;

    
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
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
        if(other.name == "Player")
        {
          
            Debug.Log("plyaer");
            inRange = true;
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
