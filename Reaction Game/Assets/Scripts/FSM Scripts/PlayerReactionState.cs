using UnityEngine;

public class PlayerReactionState : PlayerBaseState
{
    float maxReactionTime;
    float currentReactionTime;

    public override void EnterState(PlayerStateManager player)
    {
        maxReactionTime = 1f;
        currentReactionTime = 0f;
        player.boostText.enabled = true;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (Time.timeScale > 0f)
        {
            if (currentReactionTime < maxReactionTime)
            {
                currentReactionTime += Time.fixedDeltaTime;
            }else
            {
                player.boostText.enabled = false;
                player.SwitchState(player.StationaryState);
            }

            if (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                player.numOfBoosts ++;
                player.proportion = (maxReactionTime - currentReactionTime) / maxReactionTime;
                player.boostText.enabled = false;
                player.SwitchState(player.MoveUpState);
            }
        }
        


    }
}
