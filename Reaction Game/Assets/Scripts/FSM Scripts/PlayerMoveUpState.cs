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
            player.rb.velocity = Vector2.zero;
            player.SwitchState(player.StationaryState);
        }

        if (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            player.SwitchState(player.MoveDownState);
        }
    }
}
