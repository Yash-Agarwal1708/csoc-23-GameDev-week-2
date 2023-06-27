using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton instance;
    public int score = 0;
    public int kills = 0;
    // Start is called before the first frame update
    void Awake() {
        MakeSingelton();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void MakeSingelton(){
        if(instance == null){
            instance = this;
        }
    }
}
