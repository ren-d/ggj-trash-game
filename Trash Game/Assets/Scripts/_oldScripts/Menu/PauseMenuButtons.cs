using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    GameObject pauseMenu;
    bool isPaused = false;


    private void Start()
    {
        pauseMenu = GetComponent<Transform>().GetChild(0).gameObject;
    }

    private void Update()
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

    public void Pause()
    {
        FindObjectOfType<GameStateManager>().currentState = GameStateManager.GameState.PAUSED;
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
    }
    public void Unpause()
    {
        FindObjectOfType<GameStateManager>().currentState = GameStateManager.GameState.PLAYING;
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;

    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
