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

    public float maxAllowedReactionTime = 2f;

    [SerializeField]
    private float currentReactionTime;

    [HideInInspector]
    public bool boosted;

    [HideInInspector]
    public bool reacting;

    public TMP_Text boostText;

    // Start is called before the first frame update
    void Start()
    {
        boostText = GetComponent<TMP_Text>();

        randomDelay = Random.Range(minDelayTime, maxDelayTime);
        boostText = GetComponent<TMP_Text>();
        reacting = false;
        boosted = false;
        currentReactionTime = maxAllowedReactionTime + 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (reacting)
        {
            if (currentReactionTime > maxAllowedReactionTime || boosted)
            {
                reacting = false;
                boosted = false;
                boostText.enabled = false;
            }
            else if (currentReactionTime <= maxAllowedReactionTime)
                currentReactionTime += Time.fixedDeltaTime;



                
        }

        else
        {
            if (randomDelay <= 0)
            {
                randomDelay = Random.Range(minDelayTime, maxDelayTime);
                reacting = true;
                currentReactionTime = 0;
                boostText.enabled= true;
            }
            else
                randomDelay -= Time.fixedDeltaTime;
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
