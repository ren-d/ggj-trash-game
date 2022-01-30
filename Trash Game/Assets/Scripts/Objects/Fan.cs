using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    Vector3 StartPosition;
    Vector3 EndPosition;
    Vector3 Direction;
    public float windForce = 800f;
    public bool isInRange = false;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.GetChild(0).transform.position;
        EndPosition = transform.GetChild(1).transform.position;
        Direction = (EndPosition - StartPosition).normalized;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            player = col.gameObject;
            isInRange = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isInRange = false;
        }
    }

    private void FixedUpdate()
    {
        if (isInRange)
        {
            player.GetComponent<PlayerMovement>().rigidbody.AddForce(Direction * windForce, ForceMode.Acceleration);
        }
    }
}
