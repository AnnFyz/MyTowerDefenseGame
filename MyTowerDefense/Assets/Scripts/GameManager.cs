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
       
        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }


    void EndGame() // overrride this for working game over menu
    {
        gameOverUI.SetActive(true);
        gameIsOver = true;
        Time.timeScale = 0;
        //Debug.Log("Game Over");
    }
}
