using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerLevel : MonoBehaviour
{   
    private PlayerController player;
    [Header("Niveles Jugador")]
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private float actualExperience = 0f;
    [SerializeField] private float experienceForLevelUp = 200f;
    [SerializeField] private float growthExperienceLevelUp = 2f;
    [SerializeField] private float smooth = 0.25f;
    [SerializeField] private Slider expBar;
    [SerializeField] private ParticleSystem levelUpFX;
    [SerializeField] private int levelMax = 18;
    public float atractionDistance = 5f;

    private void Start()
    {
        expBar.maxValue = experienceForLevelUp;
        expBar.value = actualExperience;
    }

    private void Update()
    {
        expBar.value = Mathf.Lerp(expBar.value,actualExperience,smooth* Time.deltaTime);
    }

    public void ObtainExperience(int expAmount)
    {   
        if(currentLevel < levelMax)
        {
            actualExperience += expAmount;
            expBar.value = actualExperience;
            if(actualExperience >= experienceForLevelUp)
            {
                IncreaseLevel();
            }
        }
    }
    private void IncreaseLevel()
    {   

        Instantiate(levelUpFX,transform.position,Quaternion.identity);
        currentLevel ++;
        actualExperience -= experienceForLevelUp;
        if(currentLevel < levelMax)
        {
            experienceForLevelUp *= growthExperienceLevelUp;
            expBar.maxValue = experienceForLevelUp;
            expBar.value = actualExperience;
            player.maxHealth *= player.growthHealthUp;
            player.healthBar.maxValue = player.maxHealth;
            player.currentHealth = player.maxHealth;
            //CanvasManager.CanvasInstance.ChestCanvas();
        }
        else
        {
            expBar.value = experienceForLevelUp;
            player.currentHealth = player.maxHealth;
        }

    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, atractionDistance);
    }
}
