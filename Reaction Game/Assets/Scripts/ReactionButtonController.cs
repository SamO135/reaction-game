using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReactionButtonController : MonoBehaviour
{
    public float minDelayTime = 1f;
    public float maxDelayTime = 5f;
    
    [SerializeField]
    private float randomDelay;

    public float maxAllowedReactionTime = 1f;

    [SerializeField]
    private float currentReactionTime;

    [HideInInspector]
    public bool boosted;

    //[HideInInspector]
    public bool reacting; // True if delay is over and boost text is on screen (i.e. true during the given time they have to react to the boost message)

    public bool waitingForBoost;
    public TMP_Text boostText;

    public int numOfBoosts;
    public int maxBoosts;
    public PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {
        randomDelay = Random.Range(minDelayTime, maxDelayTime);
        boostText = GetComponent<TMP_Text>();
        reacting = false;
        boosted = false;
        currentReactionTime = maxAllowedReactionTime + 1;
        numOfBoosts = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (reacting)
        {
            if (currentReactionTime > maxAllowedReactionTime || boosted) //if boosted or run out of reaction time
            {
                reacting = false;
                boosted = false;
                boostText.enabled = false;
            }
            else if (currentReactionTime <= maxAllowedReactionTime) //if not boosted and not out of reaction time
                currentReactionTime += Time.fixedDeltaTime;
        }

        else // if not reacting
        {
            if (waitingForBoost)
            {
                if (randomDelay <= 0  && (numOfBoosts < maxBoosts)) // if delay is over and player still has boosts remaining
                {
                    randomDelay = Random.Range(minDelayTime, maxDelayTime);
                    reacting = true;
                    currentReactionTime = 0;
                    boostText.enabled = true;
                }
                else
                    randomDelay -= Time.fixedDeltaTime;
            }
                
        }
    }

    public float getCurrentReactionTime()
    {
        return currentReactionTime;
    }

    public float getMaxAllowedReactionTime()
    {
        return maxAllowedReactionTime;
    }
}
