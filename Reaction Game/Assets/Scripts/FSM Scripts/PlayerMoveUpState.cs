using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveUpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.rb.velocity = new Vector2(0, 5f*player.minSpeed);
        player.rb.AddForce(Vector2.up * player.jumpForce * player.proportion);
        Debug.Log(player.jumpForce * player.proportion);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (player.rb.velocity.sqrMagnitude < player.minSpeed)
        {
            player.rb.velocity = Vector2.zero;
            player.SwitchState(player.StationaryState);
        }

        if (Input.GetMouseButtonDown(0) && !((EventSystem.current.IsPointerOverGameObject()) && 
                                              EventSystem.current.currentSelectedGameObject != null && 
                                              EventSystem.current.currentSelectedGameObject.CompareTag("Button")) ||
            Input.GetKeyDown(KeyCode.Space))
        {
            player.SwitchState(player.MoveDownState);
        }
    }
}
