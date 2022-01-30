using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded = false;


    void OnTriggerEnter(Collider col)
    {
        isGrounded = true;
    }

    void OnTriggerExit(Collider col)
    {
        isGrounded = false;
    }

}
