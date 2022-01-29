using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    GameObject pauseMenu;
    bool isPaused = false;
    bool isMainMenu = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        pauseMenu = GetComponent<Transform>().GetChild(0).gameObject;
    }

    private void Update()
    {
        if (!isMainMenu)
        {
            if (Input.GetButtonDown("Cancel") && !isPaused)
            {
                Pause();
            }
            else if (Input.GetButtonDown("Cancel") && isPaused)
            {
                Unpause();
            }
        }  
    }

    public void OnStartPlay()
    {
        isMainMenu = false;
    }

    public void Pause()
    {
        FindObjectOfType<GameStateManager>().currentState = GameStateManager.GameState.PAUSED;
        pauseMenu.SetActive(true);
        isPaused = true;
    }
    public void Unpause()
    {
        FindObjectOfType<GameStateManager>().currentState = GameStateManager.GameState.PLAYING;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
        GameStateManager gameStateManager = FindObjectOfType<GameStateManager>();
        Destroy(gameStateManager);
        Destroy(gameObject);
    }

    public void Continue()
    {
        FindObjectOfType<GameStateManager>().currentState = GameStateManager.GameState.PLAYING;
        isPaused = false;
    }
}
