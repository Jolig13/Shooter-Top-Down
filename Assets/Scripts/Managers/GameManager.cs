using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState 
{
    Playing,
    Paused,
    Victory,
    Defeat
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    private GameState gameState;
    private int life;
    private int score;
    private float restTime;
    private bool startTime = false;
    public int min,seg;
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI scoreText;
    public GameObject[] lifeSprite;
    [SerializeField] private ParticleSystem playerDestroyFX;
    private Transform player;
    private EnemySpawner enemySpawner;
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
        life = 3;  
        score = 0; 
        startTime = true;
    }   
    private void Update()
    {
        switch(gameState)
        {
            case GameState.Playing:
                if(Input.GetKeyDown(KeyCode.Escape) && life > 0)
                {
                    gameState = GameState.Paused;
                    CanvasManager.CanvasInstance.PauseMenu();
                }
            break;
            case GameState.Paused:
                if (Input.GetKeyDown(KeyCode.Escape) && life > 0)
                {
                    gameState = GameState.Playing;
                    CanvasManager.CanvasInstance.ResumenMenu();
                }    
            break;
            case GameState.Victory:            
            break;
            case GameState.Defeat:
            break;
        }
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

    public void DamageReceive()
    {
        life --;
        lifeSprite[life].SetActive(false);
        if(life == 0)
        {   
            player.gameObject.SetActive(false);
            PlayerDeathFX();
            CanvasManager.CanvasInstance.DefeatMenu();
            enemySpawner.Spawning();
        }
    }
    public void Score()
    {
        score ++;
        scoreText.text = score.ToString();
    }
    private void PlayerDeathFX()
    {
        AudioManager.AudioInstance.PlayerDestroy();
        Instantiate(playerDestroyFX,player.position,Quaternion.identity);
    }

}
