using DarkTreeFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPlaneScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        DontDestroyOnLoad(player);
        SceneManager.LoadScene("Level2");
    }
}
