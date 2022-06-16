using UnityEngine;

public class PlayerMoveDownState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.rb.velocity = new Vector2(0, 5f*player.minSpeed);
        player.rb.AddForce(Vector2.up * player.penaltyForce);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.rb.velocity.sqrMagnitude < player.minSpeed)
        {
            player.rb.velocity = Vector2.zero;
            player.SwitchState(player.StationaryState);
        }

        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0) && !player.touchedLastFrame))
        {
            player.touchedLastFrame = true;
            player.rb.AddForce(Vector2.up * player.penaltyForce);
        }
        player.CheckReleasedTouch();
    }
}
