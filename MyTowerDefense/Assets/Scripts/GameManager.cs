using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameIsOver;
    public GameObject gameOverUI;
    public GameObject pauseUI;

    private void Start()
    {
        gameIsOver = false;
        Time.timeScale = 1;
        gameOverUI.SetActive(false);
        pauseUI.SetActive(false);
    }
    private void Update()
    {
        //if (gameIsOver)
        //    return;

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    EndGame();
        //}
    }


    void EndGame()
    {
        gameOverUI.SetActive(true);
        gameIsOver = true;
        Time.timeScale = 0;
        Debug.Log("Game Over");
    }

    void PauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void ButtonContinue()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }
}
