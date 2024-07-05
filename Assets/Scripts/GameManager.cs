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
    }

    private void Start() 
    {
        life = 3;  
        score = 0; 
        
    }

    public void DamageReceive()
    {
        life --;
        lifeSprite[life].SetActive(false);
        if(life == 0)
        {  
            SceneManager.LoadScene(0);
        }
    }
    public void Score()
    {
        score ++;
        scoreText.text = score.ToString();
    }

}
