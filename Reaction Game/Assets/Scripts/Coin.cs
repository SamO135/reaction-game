using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    /* I chose coins to be buttons as it allows for easy integration with the game, this is because I already coded it so pressing buttons 
    (i.e. pause button) mid-game does not count as a reaction press. It also means less code has to be written as I can use the 'On Click ()'
    element in the inspector to run code only when that button has been pressed (rather than adding an if-statement somewhere in the existing code).*/
    public static int numOfCoins;
    public float coinRelativeSpeed; // as coins are UI elements (buttons), they are drawn on the canvas, which in the scene is much bigger than the other
                                    // game objects like the player or ground, this means their speed/velocity needs to also be much bigger to appear similar
                                    // to the player's.
    private GameObject player;
    private Rigidbody2D playerRB, coinRect;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        coinRect = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        coinRect.velocity = playerRB.velocity * -coinRelativeSpeed;
    }

    public void CollectCoin()
    {
        numOfCoins ++;
        Destroy(gameObject);
    }
}
