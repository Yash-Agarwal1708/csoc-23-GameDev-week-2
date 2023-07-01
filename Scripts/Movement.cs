using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // You have improve this movement script. You have to make the jump mechanism more natural and snappier
    // The idea will be to add a force in the upward direction when we press space button or "w" key.  
    // For this you have to take access of the rigidbody component of the player gameobject.
    [SerializeField]
    private Rigidbody2D rb; // this is how you declare rigidbody variable

    public int coins = 0;
    public int kills = 0;
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float force_up = 500f;
    [SerializeField]
    private bool isFacingRight = true;
    [SerializeField]
    private Transform bottomPoint;
    [SerializeField] [Range(0,10)]
    private float groundedCheckRadius = 0.8f;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private GameObject[] coinSpawnLocations;

    public GameObject coinPrefab;

    public bool gameIsOn = true;

    private float v;

    [SerializeField]
    private UIManager score;

    [SerializeField]
    private AudioClip coinSound;
    [SerializeField]
    private AudioClip deathSound;
    [SerializeField]
    private AudioClip stompSound;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); // this is how you can take access of the rigidbody of the player gameobject
        coinSpawnLocations = GameObject.FindGameObjectsWithTag("Coin Spawn");
        bottomPoint = GameObject.FindGameObjectWithTag("Ground Checker").transform;
        
    }
    private void Update()
    {
        GameObject [] coins = GameObject.FindGameObjectsWithTag("Coin");

        if(coins.Length == 0)
        {
            SpawnCoins();
        }

        v = Input.GetAxis("Vertical");

        float h = Input.GetAxis("Horizontal");
        // just to get user input from wasd or arrow keys

        //Vector2 player_position = transform.position;

        // player_position.x += h * Time.deltaTime * speed;

        rb.velocity = new(h * Time.deltaTime * speed, rb.velocity.y);

        if(h < 0 && isFacingRight && gameIsOn)
        {
            Vector3 currentScale = transform.localScale;
            currentScale.x *= -1;
            transform.localScale = currentScale;
            isFacingRight = false;
            
        }
        else if(h > 0 && !isFacingRight && gameIsOn)
        {
            Vector3 currentScale = transform.localScale;
            currentScale.x *= -1;
            transform.localScale = currentScale;
            isFacingRight = true;
        }

       // transform.position = player_position;

        // here you wil add an upward force on your rb.
        // use  rb.AddForce(Vector2 force, ForceMode ), forcemode is the type of force you want to apply. It can be Impulsive or  
        // a simple force


        // So that mario falls faster than he jumps
        if(!isGrounded && rb.velocity.y > 0)
        {
            rb.gravityScale = 2;
        }
        else if(!isGrounded && rb.velocity.y < 0)
        {
            rb.gravityScale = 4;
        }
       
    }

    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(bottomPoint.position, groundedCheckRadius, groundLayer);
        if (isGrounded && gameIsOn && v > 0)
        {
            gameObject.GetComponent<AudioSource>().Play();
            rb.AddForce(Vector2.up * force_up * Time.deltaTime * v, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            coins += 1;
            AudioSource.PlayClipAtPoint(coinSound, collision.gameObject.transform.position);
            Destroy(collision.gameObject);
            score.UpdateCoins(coins);
            Debug.Log("Total Coins Collected : " + coins);
        }

        if (collision.CompareTag("Enemy"))
        {
            Collider2D[] colliders = collision.GetComponents<Collider2D>();

            foreach (Collider2D collider in colliders)
            {
                collider.enabled = false;
            }
            Debug.Log("x");
            collision.transform.localScale = new Vector3(collision.transform.localScale.x, collision.transform.localScale.y * 0.5f, collision.transform.localScale.z);
            kills++;
            AudioSource.PlayClipAtPoint(stompSound, collision.transform.position);
            score.UpdateKills(kills);
            Destroy(collision.gameObject, 0.5f);
        }

        if(collision.CompareTag("PlayerDestroyer"))
        {
            Debug.Log("Game Over");
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            score.TriggerGameOverScreen();
            Time.timeScale = 0;
        }
    }


    private void SpawnCoins()
    {
        foreach(GameObject location in coinSpawnLocations)
        {
            Instantiate(coinPrefab, location.transform.position, Quaternion.identity);
        }
    }
}
