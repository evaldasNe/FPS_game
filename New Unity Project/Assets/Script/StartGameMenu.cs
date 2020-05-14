using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameMenu : MonoBehaviour
{
    public void PlayTutorial()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PlayArcade()
    {
        SceneManager.LoadScene("Level2");
    }
    
}
