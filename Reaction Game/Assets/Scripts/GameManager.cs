using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Sprite playerImage;

    private GameObject player;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");

        if (playerImage != null)
            player.GetComponent<SpriteRenderer>().sprite = playerImage;

        /* How the shop / switching player sprites works:
        
        When the player equips a sprite from the shop, it is assigned to the 'playerImage' variable above (from the 'Shop' script).
        This Script (GameManager) is attached to the 'GameManager' GameObject in the scene which is transferred between 
        scenes using DontDestroyOnLoad. When a new Scene is loaded, the above 'Awake' method is called which
        replaces the old player sprite with the newly equipped one. */
        
    }
}
