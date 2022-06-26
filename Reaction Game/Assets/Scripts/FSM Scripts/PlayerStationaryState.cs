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

        if (Input.GetMouseButtonDown(0) && !(EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) && 
                                                EventSystem.current.currentSelectedGameObject != null && 
                                                EventSystem.current.currentSelectedGameObject.CompareTag("Button")))
        {
            player.SwitchState(player.MoveDownState);
        }
        
        
    }
}
