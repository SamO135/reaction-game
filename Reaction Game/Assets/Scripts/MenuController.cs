using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    GameObject endGame;

    void Awake()
    {
        endGame = GameObject.Find("EndGame");
    }

    void Start()
    {
        endGame.SetActive(false);
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
}
