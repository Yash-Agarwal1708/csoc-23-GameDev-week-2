using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public Transform rightSpawner;
    public Transform leftSpawner;
    public GameObject[] enemyPrefabs;
    public float speed = 4f;


    void Start()
    {
        StartCoroutine(Spawn());
    }

    
    IEnumerator Spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(3f);

            int randomIndex = Random.Range(0, enemyPrefabs.Length);

            Transform spawnPosition=(Random.Range(0,2)==0)?leftSpawner:rightSpawner;

            GameObject enemyClone = Instantiate(enemyPrefabs[randomIndex], spawnPosition.position,Quaternion.identity);

            EnemyMovement enemyScript=enemyClone.GetComponent<EnemyMovement>();

            if (spawnPosition == leftSpawner)
                enemyScript.moveSpeed = speed;

            else if (spawnPosition == rightSpawner)
            {
                enemyScript.moveSpeed = -speed;
               
            }

            enemyClone.transform.localScale = new Vector3(Mathf.Sign(enemyScript.moveSpeed), enemyClone.transform.localScale.y, 1f);
            Destroy(enemyClone,13f);
            

        }
    }
}
