using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Loadlevel(int index){
        SceneManager.LoadScene(index);
    }
}
