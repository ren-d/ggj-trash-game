using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animHandler : MonoBehaviour
{
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isMoving", false);
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        while (true)
        {
            animator.SetBool("play", true);
            yield return new WaitForSeconds(1);
            animator.SetBool("play", false);
            yield return new WaitForSeconds(2);
        }
    }

    private void Update()
    {
        
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }

    }
}
