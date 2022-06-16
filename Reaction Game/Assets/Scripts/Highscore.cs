using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Highscore : MonoBehaviour
{

    public string preceedingText;

    // Start is called before the first frame update
    void Start()
    {
        //highscoreText.text = "Highscore: " + PlayerPrefs.GetFloat("Highscore", 0f).ToString();
        GetComponent<TMP_Text>().text = preceedingText + PlayerPrefs.GetFloat("Highscore", 0f).ToString();
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetHighscore();
        }
    }

    public void ResetHighscore()
    {
        PlayerPrefs.DeleteKey("Highscore");
            GetComponent<TMP_Text>().text = preceedingText + PlayerPrefs.GetFloat("Highscore", 0f).ToString();
    }
}
