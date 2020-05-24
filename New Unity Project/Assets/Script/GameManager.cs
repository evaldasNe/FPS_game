using DarkTreeFPS;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float delayTime = 0f;

    public void Restart()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
        player.IncreaseMoney(-player.GetMoney());

        Invoke("ReloadScene", delayTime);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
