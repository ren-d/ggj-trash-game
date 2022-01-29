using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    Vector3 FanPosition;
    public float windForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        FanPosition = transform.parent.transform.position;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerMovement>().rigidbody.AddForce(Vector3.up * windForce, ForceMode.Acceleration);
        }
    }
}
