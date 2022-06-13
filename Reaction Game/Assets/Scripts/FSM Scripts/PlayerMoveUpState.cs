using UnityEngine;

public class PlayerMoveUpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.rb.velocity = new Vector2(0, 5f*player.minSpeed);
        player.rb.AddForce(Vector2.up * player.jumpForce * player.proportion);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.rb.velocity.sqrMagnitude < player.minSpeed)
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
