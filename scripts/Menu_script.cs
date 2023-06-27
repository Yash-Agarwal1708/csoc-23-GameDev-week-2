using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_script : MonoBehaviour
{
    public void exit(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        Singleton.instance.kills = 0;
    }
    public void playagain(){
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        Singleton.instance.kills = 0;
    }
}
