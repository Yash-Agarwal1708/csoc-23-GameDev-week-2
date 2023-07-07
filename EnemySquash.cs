using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquash : MonoBehaviour
{
    BoxCollider2D headCollider;
    public GameObject enemy;
    public BoxCollider2D cd1;
    public BoxCollider2D cd2;
   

    
    void Start()
    {
        headCollider= GetComponent<BoxCollider2D>();
      
    }


    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag=="Player")
        {
            float enemyY = enemy.transform.position.y;
            Destroy(headCollider);
            enemy.transform.localScale = new Vector3(1f, 1f, 1f);
            enemy.transform.position = new Vector3(enemy.transform.position.x,-4.76f , 0f);

            GameObject.Find("AudioManager").GetComponent<soundManager>().playEnemyDeath();

            Destroy(cd1);
            Destroy(cd2);

            
            Destroy (enemy,0.3f);
            
        }

    }
}
