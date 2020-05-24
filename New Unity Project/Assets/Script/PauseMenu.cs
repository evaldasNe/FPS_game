using DarkTreeFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;
    public GameObject pauseMenu;
    public GameObject OptionMenuUi;
    FPSController controller;

    private void Start()
    {
        pauseMenuUi.SetActive(false);
        controller = FindObjectOfType<FPSController>();
    }
    private void Update()
    {
        if (pauseMenuUi == false)
        {
            pauseMenu.SetActive(true);
            OptionMenuUi.SetActive(false);
        }
    }
    // Update is called once per frame
    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        controller.lockCursor = true;
        pauseMenu.SetActive(true);
        OptionMenuUi.SetActive(false);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void LoadOptions()
    {
        pauseMenu.SetActive(false);
        OptionMenuUi.SetActive(true);
    }
    public void Back()
    {
        pauseMenu.SetActive(true);
        OptionMenuUi.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
