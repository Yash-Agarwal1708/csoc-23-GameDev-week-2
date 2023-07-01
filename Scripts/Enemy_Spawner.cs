using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private Transform leftSpawner;
    [SerializeField]
    private Transform rightSpawner;
    [SerializeField]
    private float Speed = 10f;

    [SerializeField]
    private Movement game;
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        // here you have to implement the enemy spawn algorithm. The idea is very simple. 
        // You have to find a random index in the enemies array and instantiate(clone it) on either left or right spawn point and then give the clone a speed by taking access of the Enemy script component of the enemy(here it is "enemy_speed" variable). If the enemy spawns on the right speed should be negetive and vice versa
        // since you are calling this coroutine only once in the start function you to use a while loop to keep on creating enemy clones

        // some important key words: 
        while (game.gameIsOn)
        {
            int randomIndex = Random.Range(0, 2);
            int randomSpawner = Random.Range(0, 2);
            GameObject enemy = Instantiate(enemies[randomIndex],  randomSpawner == 0 ? leftSpawner.position : rightSpawner.position, Quaternion.identity);
            if(randomSpawner == 0)
            {
                enemy.GetComponent<Enemy>().SetEnemySpeed(Speed);
            }
            else
            {
                enemy.GetComponent<Enemy>().SetEnemySpeed(-Speed);
                Flip(enemy);
            }
            yield return new WaitForSeconds(1.5f);

        }

        // this line is used to wait for 1 second before executing the code below this
    }

    private void Flip(GameObject enemy)
    {
        Vector3 currentScale = enemy.transform.localScale;
        currentScale.x *= -1;
        enemy.transform.localScale = currentScale;
    }
}
