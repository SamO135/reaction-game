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
    public float targetStationaryTime = 0.5f;
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

        if (playerController.isStationary())
        {
            if (rbc.numOfBoosts >= rbc.maxBoosts) // if player has used all their boosts
            {
                if (currentStationaryTime < targetStationaryTime)
                    currentStationaryTime += Time.deltaTime;

                else        //short pause before end screen is displayed
                {
                    endGame = true;
                    endGameScreen.SetActive(true);
                    playerController.enabled = false;
                    rbc.enabled = false;
                    //menuController.ReloadScene();
                    //rbc.numOfBoosts = 0;
                    //currentStationaryTime = 0;
                }
            }
        }


        if (rbc.reacting) // if player is reacting, they are not waiting to react/boost
            rbc.waitingForBoost = false;
        else if (!rbc.reacting && playerController.isStationary()) // if player is not reacting AND not moving, they are waiting to react/boost
            rbc.waitingForBoost = true;

    }
}
