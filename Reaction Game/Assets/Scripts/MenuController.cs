using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
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
}