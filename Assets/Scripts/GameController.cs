using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;

    public static GameController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Time.timeScale = 1;
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}
