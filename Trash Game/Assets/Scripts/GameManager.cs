using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    PAUSED = 0,
    PLAYING,
    MENU,
    DIALOG
}

public enum WorldState
{
    OUTSIDE = 0,
    INSIDE,
    MENU
}
//spafce
public class GameManager : MonoBehaviour
{



    private static GameManager _instance;

    public static GameManager Instance
    { 
        // This instance of game manager can't be set to anything other than _instance
        get { 

            return _instance; 
        } 
    }

    private void Awake()
    {
        // if another instance exists on the loading of a new scene it destroys the instance
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
 
    // Game State
    private GameState _currentState = GameState.MENU;

    public void setGameState(GameState state) { _currentState = state; }
    public GameState getGameState() { return _currentState; }

    // World State
    private WorldState _currentWorld = WorldState.MENU;

    public void setWorldState(WorldState state) { _currentWorld = state; }
    public WorldState getWorldState() { return _currentWorld; }
}
