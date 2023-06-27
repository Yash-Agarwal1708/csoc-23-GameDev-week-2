using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "squash"){
            this.transform.parent.transform.localScale -= new Vector3(0,0.5f,0);
            Destroy(this.transform.parent.transform.GetChild(0).gameObject);
            Destroy(this.transform.parent.transform.GetChild(1).gameObject);
            Destroy(this.transform.parent.transform.GetChild(2).gameObject);

            Destroy(this.transform.parent.gameObject,1);
            Singleton.instance.kills++;
        }
    }
}
