using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mattress : MonoBehaviour
{
    public float yeetForce = 50f;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerMovement>().rigidbody.AddForce(Vector3.up * yeetForce, ForceMode.Impulse);
            col.gameObject.GetComponent<PlayerMovement>().isGrounded = false;
        }
    }
}
