using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    private int score;
    private float restTime;
    private bool startTime = false;
    public int min,seg;
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI scoreText;
    private Transform player;
    private EnemySpawner enemySpawner;
    private bool isPaused;
    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }   
        else
        {
            Destroy(this.gameObject);
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemySpawner = FindObjectOfType<EnemySpawner>();
        restTime = (min*60) + seg;
    }
    private void Start() 
    {
        score = 0; 
        startTime = true;
        ResumeGame();
    }   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            PausedGame();
        }
    }

    private void PausedGame()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
            CanvasManager.CanvasInstance.PauseMenu();
        }
        else 
        {
            Time.timeScale = 1f;
            CanvasManager.CanvasInstance.ResumenMenu();
        }
    }
    private void ResumeGame()
    {
        isPaused = false;
        PausedGame();
    }
    public void TimerGame() 
    {
        if(startTime) 
        {
            restTime -= Time.deltaTime;
            if(restTime < 1)
            {
                startTime = false;
                CanvasManager.CanvasInstance.VictoryMenu();
                enemySpawner.Spawning();      
            }
            int liveMin = Mathf.FloorToInt(restTime / 60);
            int liveSeg = Mathf.FloorToInt(restTime % 60);
            textTime.text = string.Format("{00:00}:{01:00}",liveMin,liveSeg);
        }  
    }
    public void LoseGame()
    {   
        enemySpawner.Spawning();           
    }
    public void Score()
    {
        score ++;
        scoreText.text = score.ToString();
    }
}
