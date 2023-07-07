using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI coinsPicked;
    public TextMeshProUGUI killCount;

    public int coins = 0;
    public float kills = 0;

    void Start()
    {
        coinsPicked.text = "CÓINS " + coins;
        killCount.text = "KILLS " + kills;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag=="Coin")
        {
            coins = coins + 1;
            Destroy(other.gameObject);
            coinsPicked.text = "COINS " + coins;
        }

       if (other.tag=="EnemyHead")
        {
            kills = kills + 1f ;
            killCount.text="KILLS "+kills;
        }
    }

}
