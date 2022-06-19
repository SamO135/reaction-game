using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerStationaryState : PlayerBaseState
{
    float randomDelay;

    // When entering the stationary state, set the activate/keep active the pause button & start delay for reaction
    public override void EnterState(PlayerStateManager player)
    {
        //Debug.Log("Hello from the Stationary State");
        player.pauseButton.SetActive(true);
        player.gameText.SetActive(true);
        randomDelay = Random.Range(player.minDelay, player.maxDelay);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (Time.timeScale > 0f)
        {
            if (player.numOfBoosts >= player.maxNumOfBoosts)
            {
                player.SwitchState(player.GameOverState);
            }

            if (randomDelay > 0)
            {
                randomDelay -= Time.deltaTime;
            }else
            {
                player.SwitchState(player.ReactionState);
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    player.SwitchState(player.MoveDownState);
                }
            }
        }
        
        
    }
}
