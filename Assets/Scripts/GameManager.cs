using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    private int life;
    private int score;
    private float restTime;
    private bool startTime = false;
    public int min,seg;
    public TextMeshProUGUI textTime;

    public TextMeshProUGUI scoreText;
    public GameObject[] lifeSprite;

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

        restTime = (min*60) + seg;
    }

    private void Start() 
    {
        life = 3;  
        score = 0; 
        startTime = true;
        
    } 
    public void TimerGame() 
    {
        if(startTime) 
        {
            restTime -= Time.deltaTime;
            if(restTime < 1)
            {
                startTime = false;
                SceneManager.LoadScene(0);
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
            SceneManager.LoadScene(0);
            AudioManager.AudioInstance.PlayerDestroy();
        }
    }
    public void Score()
    {
        score ++;
        scoreText.text = score.ToString();
    }

}
