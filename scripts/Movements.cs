using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 10f;
    public float jumpspeed = 10f;
    private bool grounded = true;
    public LayerMask groundlayer;
    public Transform groundcheck;
    public float ground_radius;
    public int kills = 0;
    public int score = 0;
    // Start is called before the first frame update
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position, ground_radius, groundlayer);
        float h = Input.GetAxis("Horizontal");

        Vector2 player_position = transform.position;

        player_position.x += h * Time.deltaTime * speed;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
        }

        transform.position = player_position;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Coin"){
            ++score;
            Singleton.instance.score = score;
            Destroy(other.gameObject);
        }
    }
}
