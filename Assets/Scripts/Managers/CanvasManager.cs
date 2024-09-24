using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{   
    public static CanvasManager CanvasInstance {get; private set;}
    [SerializeField] private GameObject victoryCanvas;
    [SerializeField] private GameObject defeatCanvas;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private float delay;

    private void Awake()
    {
        if (CanvasInstance == null)
        {
            CanvasInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }   

    public void VictoryMenu()
    {
        Invoke("ShowVictoryCanvas",delay);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
            enemy.gameObject.GetComponent<MeleeEnemyScript>().DeathFX();
        }

    }
    public void DefeatMenu()
    {   
        Invoke("ShowDefeatCanvas",delay);
    }

    public void Quit()
    {
        Debug.Log("Juego Cerrado");
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void PauseMenu()
    {    
        pauseCanvas.SetActive(true);
    }
    public void ResumenMenu()
    {   
        pauseCanvas.SetActive(false); 
    }

    private void ShowVictoryCanvas()
    {
        victoryCanvas.SetActive(true);
    }
    private void ShowDefeatCanvas()
    {
        defeatCanvas.SetActive(true);
    }  
}

