using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public MenuController menuController;
    public GameObject mainMenu, endGame, pauseButton;

    private GameObject player;
    private Rigidbody2D playerRB;
    private bool attemptedCoinSpawn;
    public Coin coinPrefab;
    private float canvasWidth, canvasHeight;
    private GameObject canvas;
    public float coinSpawnChance = 30;
    private int displayWidth, displayHeight;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        //(canvasWidth, canvasHeight) = (GetComponent<RectTransform>().rect.width, GetComponent<RectTransform>().rect.height);
        canvas = GameObject.FindWithTag("Canvas");
        displayWidth = Display.main.systemWidth;
        displayHeight = Display.main.systemHeight;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!attemptedCoinSpawn && Mathf.Abs(playerRB.position.y % 10) < 1)
        {
            attemptedCoinSpawn = true;
            if (Random.Range(1, 100) <= coinSpawnChance)
            {
                float x = Random.Range(100, displayWidth - 100);
                float y = displayHeight + 100f;
                
                Coin coin = Instantiate(coinPrefab, new Vector3(x, y, 0), Quaternion.identity);
                coin.transform.SetParent(canvas.transform);
            }
        }
        else if (Mathf.Abs(playerRB.position.y % 10) > 1)
            attemptedCoinSpawn = false;



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
