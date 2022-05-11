using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public string score;
    public Score scoreScript;
    public TMP_Text finalScoreText;
    // Start is called before the first frame update
    void Start()
    {
        finalScoreText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        score = "Score: " + scoreScript.score;
        finalScoreText.text = score;
    }
}
