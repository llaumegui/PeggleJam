using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameObject PauseScreen;

    private bool isPaused = false;

    private void Awake()
    {
        PauseScreen = transform.GetChild(0).gameObject;

        PauseScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!isPaused)
            {
                isPaused = true;
                Time.timeScale = 0; // stop tout ce qui focntionne avec le Time (FixedUpdate, animation etc....)
                PauseScreen.SetActive(true);
            }
            else
            {
                isPaused = false;
                Time.timeScale = 1;
                PauseScreen.SetActive(false);
            }
        }
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
