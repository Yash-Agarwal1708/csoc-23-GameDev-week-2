using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    public Rigidbody2D player;
    

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        
    }

 
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, 0f);
    }
    
}
