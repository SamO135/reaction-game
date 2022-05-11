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
    public float score;
    private RectTransform scoreTransform;
    public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.endGame)
            scoreText.enabled = false;
        else
            scoreText.enabled = true;

        score = Mathf.Round(player.position.y + 3);
        scoreText.text = score.ToString();
    }
}
