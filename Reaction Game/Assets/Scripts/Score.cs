using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform player;
    public TMP_Text scoreText;
    [HideInInspector]
    public string score;
    private RectTransform scoreTransform;
    //public GameController gameController;
    public GameObject endGameScreen;
    public int decimals;
    private float startingPos;

    // Start is called before the first frame update
    void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
        score = "0";
        startingPos = player.position.y;

        //endGameScreen = GameObject.Find("EndGame");
    }

    // Update is called once per frame
    void Update()
    {
        if (endGameScreen.activeInHierarchy)
            scoreText.enabled = false;
        else
            scoreText.enabled = true;

        score = (player.position.y - startingPos).ToString("F" + decimals.ToString());

        if (float.Parse(score) <= 0.0f)
            score = "0";
        scoreText.text = score;
    }
}
