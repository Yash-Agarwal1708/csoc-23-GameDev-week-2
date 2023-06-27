using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_movement : MonoBehaviour
{
        public Transform Player;
        Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Player){
            transform.position = new Vector3 (Player.position.x-1,Player.position.y,-10);
        }
    }
}
