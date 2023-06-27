using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform leftSpawner;
    public Transform rightSpawner;
    public float Speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    IEnumerator spawn()
    {
        while(true){
            int r = Random.Range(0,2);
            if(r==0){
                GameObject clone = Instantiate(enemies[0], leftSpawner.position, leftSpawner.rotation) as GameObject;
                clone.gameObject.GetComponent<Enemy>().enemy_speed = Speed;
            }
            else{
                GameObject clone = Instantiate(enemies[0], rightSpawner.position, rightSpawner.rotation) as GameObject;
                clone.gameObject.GetComponent<Enemy>().enemy_speed = -Speed;
            }
        yield return new WaitForSeconds(5f);
        }
    }
}
