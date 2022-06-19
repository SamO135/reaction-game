using UnityEngine;
using UnityEngine.EventSystems;

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
                currentReactionTime += Time.deltaTime;
            }else
            {
                player.boostText.enabled = false;
                player.SwitchState(player.StationaryState);
            }

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
            {
                if (!((EventSystem.current.IsPointerOverGameObject() || EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) && 
                      EventSystem.current.currentSelectedGameObject != null && 
                      EventSystem.current.currentSelectedGameObject.CompareTag("Button")))
                {
                    player.numOfBoosts ++;
                    player.proportion = (maxReactionTime - currentReactionTime) / maxReactionTime;
                    player.boostText.enabled = false;
                    player.SwitchState(player.MoveUpState);
                }
                
            }

        }
        


    }
}
