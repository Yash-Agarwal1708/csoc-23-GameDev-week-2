using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;


    
    void Update()
    {
        transform.position = player.position + new Vector3(-1f, 0f,-10f);
    }
}
