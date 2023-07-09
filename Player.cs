using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPOS;
    public float speed;
    public float MovementInY;

    public float maxHeight;
    public float minHeight;

    public int health = 3;

    public GameObject effect;
    public Text healthDisplay;
    public GameObject popSound;

    private void Update()
    {
        healthDisplay.text = health.ToString();
        
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        transform.position = Vector2.MoveTowards(transform.position, targetPOS, speed * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            Instantiate(popSound, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPOS = new Vector2(transform.position.x,transform.position.y + MovementInY);
        }else if(Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight) 
        {
            Instantiate(popSound, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPOS = new Vector2(transform.position.x, transform.position.y - MovementInY);
        }
    }
}