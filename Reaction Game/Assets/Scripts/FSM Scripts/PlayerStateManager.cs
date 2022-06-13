using UnityEngine;
using TMPro;

public class PlayerStateManager : MonoBehaviour
{

    public PlayerBaseState currentState;
    public PlayerStationaryState StationaryState = new PlayerStationaryState();
    public PlayerReactionState ReactionState = new PlayerReactionState();
    public PlayerMoveUpState MoveUpState = new PlayerMoveUpState();
    public PlayerMoveDownState MoveDownState = new PlayerMoveDownState();
    public PlayerGameOverState GameOverState = new PlayerGameOverState();

    public Rigidbody2D rb;
    public TMP_Text boostText;
    public MenuController menuController;
    public GameObject pauseButton;
    public int jumpForce;
    public int penaltyForce;
    public float minSpeed;
    public float minDelay;
    public float maxDelay;
    public int maxNumOfBoosts;
    [HideInInspector]
    public int numOfBoosts;
    [HideInInspector]
    public float playerReactionTime;
    [HideInInspector]
    public float proportion;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        penaltyForce *= -1;

        currentState = StationaryState;
        currentState.EnterState(this);

    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

}
