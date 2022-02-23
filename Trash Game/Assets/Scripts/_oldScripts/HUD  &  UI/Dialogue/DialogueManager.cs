using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator animator;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();

    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText = GameObject.Find("npcName").GetComponent<TMP_Text>();
        dialogueText = GameObject.Find("npcDialog").GetComponent<TMP_Text>();
        animator = GameObject.Find("DialogBox").GetComponent<Animator>();
        animator.SetBool("isOpen", true);
        FindObjectOfType<GameStateManager>().setGameState(GameStateManager.GameState.DIALOG);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        FindObjectOfType<GameStateManager>().setGameState(GameStateManager.GameState.PLAYING);
        Debug.Log("end of convo");
    }
}
