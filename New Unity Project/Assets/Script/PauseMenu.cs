using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;
    public GameObject Canvas;
    public GameObject PlayerModel;
    private GameObject Target;

    private void Start()
    {
        Target = GameObject.Find("Crosshair Canvas");
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Canvas.SetActive(true);
        Target.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        PlayerModel.GetComponent<PlayerGunController>().enabled = true;
    }
    void Pause ()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Canvas.SetActive(false);
        Target.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        PlayerModel.GetComponent<PlayerGunController>().enabled = false;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
