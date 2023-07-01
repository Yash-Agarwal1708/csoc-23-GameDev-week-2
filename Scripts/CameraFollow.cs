using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player; // this is to get the transform component of the player gameobject
    [SerializeField]
    private Vector3 offset;
    // Update is called once per frame
    void LateUpdate()
    {
        //here you have to update the position of the camera which will be equal to that of player but be carefull about the z direction 
        transform.position = player.position + offset ;
    }
}

// In this script you have to make the position of camera to follow the player so that the player doesn't go outside the screen
