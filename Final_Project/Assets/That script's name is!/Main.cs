using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public Text timer;
    public Text Score;
    public Text Lives;
    public Text Level;
    float dateTime;
    public GameObject[] mazes;
    public GameObject currentMaze;
    public int level = 1;
    [SerializeField] public GameObject pauseMenu;

    static public Main S;

    [Header("Set in Inspector")]
    float timeForEachLevel = 240;
    public int score = 0;
    public int lives = 3;
    public GameObject SpawnPositionGO;
    GameObject[] balloons;
    GameObject[] bombs;
    public GameObject balloonPrefab;
    public GameObject bombPrefab;
    public GameObject redZonePrefab;

    // Start is called before the first frame update
    void Start()
    {
        S = this;
        level = 1;
        score = 0;
        lives = 3;
        currentMaze = GameObject.FindGameObjectWithTag("Maze");
        ResetTime();
    }

    // Update is called once per frame
    void Update()
    {
        ShowTime();
        UpdateScore();
        UpdateLives();
        UpdateLevel();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Pause();
        }
        balloons = GameObject.FindGameObjectsWithTag("Balloon");
        bombs = GameObject.FindGameObjectsWithTag("Bomb");
        if(level > 3)
        {
            SceneManager.LoadScene("Win_Scene");
        }
        if(balloons.Length == 0)
        {
            StartLevel();
            //SceneManager.LoadScene("Win_Scene");
        }
       
    }
    void ShowTime()
    {
        int timePassed = (int)(Time.time - dateTime);
        int timeLeft = (int)(timeForEachLevel - timePassed);
        int minutes = timeLeft / 60;
        int seconds = timeLeft % 60;
        DateTime time = DateTime.Now;
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if(minutes == 0 && seconds == 0)
        {
            SceneManager.LoadScene("GameOver_Scene");
        }
    }
    void ResetTime()
    {
        dateTime = Time.time;
    }
    void StartLevel()
    {
        Destroy(currentMaze);
        currentMaze = Instantiate<GameObject>(mazes[level - 1]);
        currentMaze.transform.position = new Vector3(0f, 0f, 0f);
        
        switch (level)
        {
            case 1:
                {
                    SpawnPositionGO.transform.position = new Vector3(-7.4f, .4f, 0f);
                    var bee = GameObject.Find("BeeAnchor");
                    bee.transform.position = SpawnPositionGO.transform.position;
                    for (int i = 0; i <= 10; i++ )
                    {
                        if(i < 5)
                        {
                            GameObject lineSpawn = Instantiate<GameObject>(balloonPrefab);
                            lineSpawn.transform.position = new Vector3(1 + i, 1 - i, 0);
                        }
                        else
                        {
                            GameObject diagonalSpawn = Instantiate<GameObject>(balloonPrefab);
                            diagonalSpawn.transform.position = new Vector3(-4 + i, 1, 0);
                        }
                    }
                    GameObject go = Instantiate<GameObject>(balloonPrefab);
                    go.transform.position = new Vector3(-8.64f, -1.24f, 0);
                    go = Instantiate<GameObject>(balloonPrefab);
                    go.transform.position = new Vector3(6.57f, 3.77f, 0);
                    go = Instantiate<GameObject>(balloonPrefab);
                    go.transform.position = new Vector3(-7.15f, -2.91f, 0);
                    GameObject bomb = Instantiate<GameObject>(bombPrefab);
                    bomb.transform.position = new Vector3(-5.48f, 4.03f, 0);
                    bomb = Instantiate<GameObject>(bombPrefab);
                    bomb.transform.position = new Vector3(9.945633f, 2.449546f, 0);
                    break;
                }
            case 2:
                {
                    SpawnPositionGO.transform.position = new Vector3(-5.687f, -2.748f, 0f);
                    var bee = GameObject.Find("BeeAnchor");
                    bee.transform.position = SpawnPositionGO.transform.position;
                    currentMaze.transform.position = new Vector3(0f, 3f, 0f);
                    GameObject go = Instantiate<GameObject>(balloonPrefab);
                    go.transform.position = new Vector3(.88f, -2.42f, 0);
                    go = Instantiate<GameObject>(balloonPrefab);
                    go.transform.position = new Vector3(4.07f, -.82f, 0);
                    go = Instantiate<GameObject>(balloonPrefab);
                    go.transform.position = new Vector3(-5.15f, -2.11f, 0);
                    go = Instantiate<GameObject>(balloonPrefab);
                    go.transform.position = new Vector3(6.21f, -1.96f, 0);
                    go = Instantiate<GameObject>(balloonPrefab);
                    go.transform.position = new Vector3(10.02f, 2.8f, 0);
                    go = Instantiate<GameObject>(balloonPrefab);
                    go.transform.position = new Vector3(-6.04f, -2.75f, 0);
                    go = Instantiate<GameObject>(balloonPrefab);
                    go.transform.position = new Vector3(.99f, 3.27f, 0);
                    go = Instantiate<GameObject>(balloonPrefab);
                    go.transform.position = new Vector3(-2.41f, 1.67f, 0);
                    go = Instantiate<GameObject>(balloonPrefab);
                    go.transform.position = new Vector3(5.01f, 3.4f, 0);
                    go = Instantiate<GameObject>(balloonPrefab);
                    go.transform.position = new Vector3(3.77f, -1.19f, 0);
                    go = Instantiate<GameObject>(balloonPrefab);
                    go.transform.position = new Vector3(3.07f, 1.65f, 0);
                    foreach(var bomb in bombs)
                    {
                        Destroy(bomb);
                    }
                    GameObject redZone = Instantiate<GameObject>(redZonePrefab);
                    redZone.transform.position = new Vector3(6f, 0, 0);
                    redZone = Instantiate<GameObject>(redZonePrefab);
                    redZone.transform.position = new Vector3(0, 0, 0);
                    break;
                }
                

           
        }
        level++;
        
        
    }

    void UpdateScore()
    {
        Score.text = "Score: " + score; 
    }

    void UpdateLives()
    {
        Lives.text = "Lives: " + lives; 
    }
    void UpdateLevel()
    {
        Level.text = "Level:" + level;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
