using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
        public Rigidbody2D enemy_rb;
        public float enemy_speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        enemy_rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy_rb.velocity = new Vector3(enemy_speed, enemy_rb.velocity.y, 0);
    }
}
