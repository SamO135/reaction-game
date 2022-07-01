using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveBetweenScenes : MonoBehaviour
{
    private static SaveBetweenScenes playerInstance; 
    // Start is called before the first frame update
    void Awake()
    {
        if (playerInstance == null)
        {
            playerInstance = this;
        }  
        else
        {
            Destroy(gameObject);
        }
            
        DontDestroyOnLoad(gameObject);
    }

}
