using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // this script is basically used to give our enemy some speed when it is spawned;
    [SerializeField]
    private Rigidbody2D enemy_rb;
    [SerializeField]
    private float enemy_speed;
    void Start()
    {
        // enemy_rb;
        enemy_rb = gameObject.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        enemy_rb.velocity = new Vector3(enemy_speed, enemy_rb.velocity.y, 0);
        // giving the enemy rigidbody a velocity. this velocity will manipulate in the Enemy_Spawner script
    }

    public void SetEnemySpeed(float speed)
    {
        enemy_speed = speed;
    }
    
}
