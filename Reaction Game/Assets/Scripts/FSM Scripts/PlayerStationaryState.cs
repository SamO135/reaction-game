using UnityEngine;

public class PlayerStationaryState : PlayerBaseState
{
    float randomDelay;

    public override void EnterState(PlayerStateManager player)
    {
        //Debug.Log("Hello from the Stationary State");
        randomDelay = Random.Range(player.minDelay, player.maxDelay);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.numOfBoosts >= player.maxNumOfBoosts)
        {
            player.SwitchState(player.GameOverState);
        }

        if (randomDelay > 0)
        {
            randomDelay -= Time.fixedDeltaTime;
        }else
        {
            player.SwitchState(player.ReactionState);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.SwitchState(player.MoveDownState);
        }
        
    }
}
