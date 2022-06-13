using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public MenuController menuController;
    public GameObject mainMenu, endGame, pauseButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuController.TogglePauseMenu();
        }*/


        // pause button logic - if a menu is on screen then don't show the pause button so the
        // player can't pause the game. I moved this code so it is part of the state machine (as 
        // that way the code isn't run every frame like it is here): The pause button gets 
        // activated in the StationaryState, and deactivated in the GameOverState.

        /*if (mainMenu.activeInHierarchy || endGame.activeInHierarchy)
        {
            pauseButton.SetActive(false);
        }
        else
        {
            pauseButton.SetActive(true);
        }*/
    }
}
