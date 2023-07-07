using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using TMPro;

public class Enemy_PlayerDestroy : MonoBehaviour
{
   
    CapsuleCollider2D bodyCollider;

    public GameObject gameOver;
    public GameObject Score;
    public GameObject gameCanvas;

    public TextMeshProUGUI CoinsPicked;
    public TextMeshProUGUI KillCount;

    ScoreManager scoreScript;


    void Update()
    {
        bodyCollider= GetComponent<CapsuleCollider2D>();
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="EnemyBody")
        {
            ScoreManager scoreScript = GetComponent<ScoreManager>();
            Destroy(other.gameObject);
            gameObject.GetComponentInParent<Transform>().GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("AudioManager").GetComponent<soundManager>().playPlayerDeath();

            gameOver.SetActive(true);
            Score.SetActive(true);
            gameCanvas.SetActive(false);

            CoinsPicked.text = "COINS " + scoreScript.coins;
            KillCount.text = "KILLS " + scoreScript.kills;

            Debug.Log("DVGSD");

            Time.timeScale = 0f;
            
           
        }
    }

    
}
