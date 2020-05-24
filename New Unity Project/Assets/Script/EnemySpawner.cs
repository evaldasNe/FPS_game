using DarkTreeFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject spiderPreftab;
    public GameObject fatmanpreftab;

    public PlayerStats player;
    public float Spawntime = 5;
    public float spawnInterval = 2; //Spawn new enemy each n seconds
    public int enemiesPerWave = 5; //How many enemies per wave
    public int enemiesPerWaveincrease = 2;
    public Transform[] spawnPoints;

    public float nextSpawnTime = 10;
    int waveNumber = 1;
    public bool waitingForWave = true;
    public float newWaveTimer = 10;
    int enemiesToEliminate;
    //How many enemies we already eliminated in the current wave
    int enemiesEliminated = 0;
    int totalEnemiesSpawned = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Wait 10 seconds for new wave to start
        waitingForWave = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitingForWave)
        {
            if (newWaveTimer >= 0)
            {
                newWaveTimer -= Time.deltaTime;
            }
            else
            {
                //Initialize new wave
                enemiesToEliminate = ((waveNumber-1)*enemiesPerWaveincrease) + enemiesPerWave;
                enemiesEliminated = 0;
                totalEnemiesSpawned = 0;
                waitingForWave = false;

                var shop = GameObject.Find("Shop");
                if (shop != null)
                {
                    shop.SetActive(false);
                    var player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
                    player.isShopActive = false;
                    player.lockCursor = true;
                    player.mouseLookEnabled = true;
                }
                    
            }
        }
        else
        {
            if (Time.time > nextSpawnTime)
            {
                nextSpawnTime = Time.time + spawnInterval;

                //Spawn enemy 
                if (totalEnemiesSpawned < enemiesToEliminate)
                {
                    Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];

                    GameObject enemy = Instantiate(enemyPrefab, randomPoint.position, Quaternion.identity);
                    EnemyScript npc = enemy.GetComponent<EnemyScript>();
                    npc.target= player.transform;
                    npc.es = this;
                    totalEnemiesSpawned++;
                    if(waveNumber > 2)
                    {
                        GameObject spider = Instantiate(spiderPreftab, randomPoint.position, Quaternion.identity);
                        SpiderScript npc1 = spider.GetComponent<SpiderScript>();
                        npc1.target = player.transform;
                        npc1.es = this;
                        totalEnemiesSpawned++;
                    }
                }
            }
        }
        if (player.health <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2 - 50, 10, 100, 25), (enemiesToEliminate - enemiesEliminated).ToString());

        if (waitingForWave)
        {
            GUI.Box(new Rect(Screen.width / 2 - 125, Screen.height / 4 - 12, 250, 25), "Waiting for Wave " + waveNumber.ToString() + ". " + ((int)newWaveTimer).ToString() + " seconds left...");
        }
    }

    public void EnemyEliminated()
    {
        enemiesEliminated++;

        if (enemiesToEliminate - enemiesEliminated <= 0)
        {
            //Start next wave
            newWaveTimer = Spawntime;
            waitingForWave = true;
            waveNumber++;
        }
    }
}
