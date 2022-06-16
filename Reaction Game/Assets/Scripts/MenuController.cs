using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject endGame, pauseMenu;


    void Awake()
    {
        //endGame = GameObject.Find("EndGame");
        //pauseMenu = GameObject.Find("PauseMenu");
    }

    void Start()
    {
        //endGame.SetActive(false);
    }

    public void OpenShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenEndGameScreen()
    {
        endGame.SetActive(true);
    }

    /*public void OpenPauseMenu()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }*/

    public void TogglePauseMenu()
    {
        if (pauseMenu.activeInHierarchy)
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }
}
