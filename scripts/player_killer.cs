using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_killer : MonoBehaviour
{
    public GameObject end_menu;
    public void pause(){
        end_menu.SetActive(true);
        Time.timeScale = 0f;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            Destroy(other.gameObject);
            pause();
        }
    }
}
