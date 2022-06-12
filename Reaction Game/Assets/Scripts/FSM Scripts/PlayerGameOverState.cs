using UnityEngine;

public class PlayerGameOverState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("End Game");
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.menuController.OpenEndGameScreen();
    }
}
