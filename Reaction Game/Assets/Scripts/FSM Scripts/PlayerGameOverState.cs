using UnityEngine;

public class PlayerGameOverState : PlayerBaseState
{
    // When the game has finished, deactivate the pause button.
    public override void EnterState(PlayerStateManager player)
    {
        player.pauseButton.SetActive(false);
        player.gameText.SetActive(false);
        if (float.Parse(player.score.text) > PlayerPrefs.GetFloat("Highscore", 0f)) // if score > highscore
            PlayerPrefs.SetFloat("Highscore", float.Parse(player.score.text)); // update highscore
    }

    // While in game over state, keep the end game screen open. (for some reason this didn't work in the
    // EnterState method, so I had to put it in here.)
    public override void UpdateState(PlayerStateManager player)
    {
        player.menuController.OpenEndGameScreen();
    }
}
