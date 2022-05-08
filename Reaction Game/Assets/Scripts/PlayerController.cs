using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float minSpeed;
    public int jumpForce;
    public int penaltyForce;
    public Rigidbody2D rb;

    //[SerializeField]
    public ReactionButtonController rbc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        penaltyForce *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (rbc.reacting)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                float proportion = ((rbc.getMaxAllowedReactionTime() - rbc.getCurrentReactionTime()) / rbc.getMaxAllowedReactionTime());
                rb.AddForce(Vector2.up * jumpForce * proportion);
                Debug.Log("Force: " + jumpForce * proportion);
                rbc.boosted = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * penaltyForce);
                Debug.Log("Too early!");
            }
        }

        if (rb.velocity.sqrMagnitude < minSpeed)
        {
            rb.velocity = new Vector2 (0, 0);
        }
        
    }
}
