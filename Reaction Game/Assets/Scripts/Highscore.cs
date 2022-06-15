using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{

    public TMP_Text highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = "Highscore: " + PlayerPrefs.GetFloat("Highscore", 0f).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("Highscore");
            highscoreText.text = "Highscore: " + PlayerPrefs.GetFloat("Highscore", 0f).ToString();
        }
    }
}
