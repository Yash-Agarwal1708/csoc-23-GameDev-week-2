using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    private int playSceneBuildIndex = 1;
    private int mainMenuSceneBuildIndex = 0;
    [SerializeField]
    private TextMeshProUGUI killText;
    [SerializeField]
    private TextMeshProUGUI coinText;
    [SerializeField]
    private GameObject gameOverScreen;

    public void UpdateKills(int kills)
    {
        killText.text = "KILLS: " + kills;
    }

    public void UpdateCoins(int coins)
    {
        coinText.text = "COINS : " + coins;
    }
    
    public void TriggerGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Play()
    {
        SceneManager.LoadScene(playSceneBuildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenuSceneBuildIndex);
    }
}
