using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + Singleton.instance.score.ToString();
    }
}
