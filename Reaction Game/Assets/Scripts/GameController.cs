using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //public int numOfBoosts;
    //public int maxBoosts;
    public MenuController menuController;
    public PlayerController playerController;
    public ReactionButtonController rbc;
    public GameObject endGameScreen;
    public float targetStartionaryTime;
    private float currentStationaryTime;

    public bool endGame;

    // Start is called before the first frame update
    void Start()
    {
        currentStationaryTime = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (rbc.numOfBoosts >= rbc.maxBoosts)
        {
            if (playerController.isStationary())
            {
                if (currentStationaryTime < targetStartionaryTime)
                    currentStationaryTime += Time.deltaTime;
                else
                {
                    endGame = true;
                    endGameScreen.SetActive(true);
                    //menuController.ReloadScene();
                    //rbc.numOfBoosts = 0;
                    //currentStationaryTime = 0;
                }
            }
        }

    }
}
