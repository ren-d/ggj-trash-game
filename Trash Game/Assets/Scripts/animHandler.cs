using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animHandler : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            animator.SetFloat("Blend", 1);
        }
    }
}
