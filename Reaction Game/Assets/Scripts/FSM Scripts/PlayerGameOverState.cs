using UnityEngine;

public class PlayerGameOverState : PlayerBaseState
{
    // When the game has finished, deactivate the pause button.
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("End Game");
        player.pauseButton.SetActive(false);
    }

    // While in game over state, keep the end game screen open. (for some reason this didn't work in the
    // EnterState method, so I had to put it in here.)
    public override void UpdateState(PlayerStateManager player)
    {
        player.menuController.OpenEndGameScreen();
    }
}
