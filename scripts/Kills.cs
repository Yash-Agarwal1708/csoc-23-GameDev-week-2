using UnityEngine;
using UnityEngine.UI;

public class Kills : MonoBehaviour
{
    public Text kills;

    // Update is called once per frame
    void Update()
    {
        kills.text = "Kills: " + Singleton.instance.kills.ToString();
    }
}
