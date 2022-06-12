using UnityEngine;

public class PlayerMoveUpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.rb.velocity = new Vector2(0, 1.5f*player.minSpeed);
        player.rb.AddForce(Vector2.up * player.jumpForce * player.proportion);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.rb.velocity.sqrMagnitude < player.minSpeed) // I think this is true at the start of the boost (when it is speeding up but still moving slower than the 'minSpeed'), which causes the state to be switched to the stationary state even though the player is moving.
        {
            player.rb.velocity = new Vector2(0, 0);
            player.SwitchState(player.StationaryState);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.SwitchState(player.MoveDownState);
        }
    }
}
