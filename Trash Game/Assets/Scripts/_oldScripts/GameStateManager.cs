using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStateManager : MonoBehaviour
{
    
    public enum GameState
    {
        MENU, 
        DIALOG,
        PLAYING,
        PAUSED,
    }

    public enum GameScene
    {
        MENU,
        TRASHYARD,
        IMAGINATION,
    }

    public GameScene currentSceneState;
    public GameState currentState;
    Scene currentScene;
    public Vector3 playerScrapPos;
    public void setGameState(GameState newState)
    {
        currentState = newState;
    }

    private void Awake()
    {

        playerScrapPos = new Vector3(0, 10, 0);

        int amountOfManagers = FindObjectsOfType<GameStateManager>().Length;
        if (amountOfManagers != 1)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
        currentSceneState = GameScene.TRASHYARD;
        currentState = GameState.PLAYING;
    }
    
    private void FixedUpdate()
    {
        
        switch (currentSceneState)
        {
            case GameScene.MENU:

                switch (currentState)
                {
                    case GameState.MENU:
                        break;
                    case GameState.DIALOG:
                        break;
                    case GameState.PLAYING:
                        break;
                    case GameState.PAUSED:
                        break;
                }
                break;
            case GameScene.TRASHYARD:

                switch (currentState)
                {
                    case GameState.MENU:
                        break;
                    case GameState.DIALOG:
                        break;
                    case GameState.PLAYING:
                        Time.timeScale = 1;
                        break;
                    case GameState.PAUSED:
                        break;
                }
                break;
            case GameScene.IMAGINATION:

                switch (currentState)
                {
                    case GameState.MENU:
                        break;
                    case GameState.DIALOG:
                        break;
                    case GameState.PLAYING:
                        Time.timeScale = 1;
                        break;
                    case GameState.PAUSED:
                        break;
                }
                break;
        }

    }
}
