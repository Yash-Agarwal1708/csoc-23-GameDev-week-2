using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public AudioSource playerDeath;
    public AudioSource enemyDeath;
    
    public AudioSource coinPickup;

    public void playPlayerDeath()
    {
        playerDeath.Play();
    }

    public void playEnemyDeath()
    {
        enemyDeath.Play();
    }

    

    public void playCoinPickup()
    {
        
        coinPickup.Play();
    }
}
