using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum GameState
    { 
        PAUSED = 0,
        PLAYING,
        MENU,

    
    }

    private static GameManager _instance;

    public static GameManager Instance
    { 
        //This instance of game manager can't be set to anything other than _instance
        get { 

            return _instance; 
        } 
    }

    private void Awake()
    {
        //if another instance exists on the loading of a new scene it destroys the instance
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    
}
