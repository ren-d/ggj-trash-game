using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    Vector3 respawnPosition;
    Quaternion respawnRotation;

    // Start is called before the first frame update
    void Start()
    {
        respawnPosition = transform.position;
        respawnRotation = transform.rotation;
    }

    public void RespawnPlayer()
    {
        transform.SetPositionAndRotation(respawnPosition, respawnRotation);
    }
}
