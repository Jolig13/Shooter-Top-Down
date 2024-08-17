using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IDamageReceive
{      
    public static PlayerController playerInstance {get; private set;}

    [Header("Movimiento")]
    private Rigidbody2D rb;
    private float inputX;
    private float inputY; 
    [SerializeField]private float baseSpeed;
    [SerializeField] private float speedAceleration;
    [SerializeField]private float moveSpeed;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Camera virtualCamera;
    [SerializeField] private ParticleSystem enginePS;
    [Header("Limites")]
    [SerializeField] private float minX; 
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [Header("Vida Jugador")]
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth;
    [SerializeField] private ParticleSystem playerDeadFX;
    [SerializeField] private Slider healthBar;
    [SerializeField] private float smooth = 0.25f;
    [SerializeField] private float growthHealthUp =2.5f;
    [Header("Niveles Jugador")]
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private float actualExperience = 0f;
    [SerializeField] private float experienceForLevelUp = 200f;
    [SerializeField] private float growthExperienceLevelUp = 2f;
    [SerializeField] private Slider expBar;
    [SerializeField] private ParticleSystem levelUpFX;
    [SerializeField] private int levelMax = 18;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        enginePS.Stop(); 
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        expBar.maxValue = experienceForLevelUp;
        expBar.value = actualExperience;

    }

    private void Update()
    {     
        if(Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
        healthBar.value = Mathf.Lerp(healthBar.value,currentHealth,smooth* Time.deltaTime);
        expBar.value = Mathf.Lerp(expBar.value,actualExperience,smooth* Time.deltaTime);
        GameManager.Instance.TimerGame();
    }
    private void FixedUpdate()
    {
        Movement();
        CheckLimits();
    }

    private void Movement()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        moveSpeed = baseSpeed * speedAceleration * Time.deltaTime;
        //Speed Limit
        rb.velocity = Vector2.ClampMagnitude(rb.velocity,moveSpeed);
        //Add Speed, Aceleration for move
        Vector2 movePlayer = new Vector2(inputX, inputY).normalized * moveSpeed;
        rb.AddForce(movePlayer);
        
        //rb.MovePosition(rb.position+movePlayer*moveSpeed*Time.deltaTime);
        

        Vector2 MouseDirection = virtualCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 LookDirection = MouseDirection - rb.position;
        float angle = Mathf.Atan2(LookDirection.y, LookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        if (movePlayer != Vector2.zero)
        {
            enginePS.Play();
        }
        else
        {
            enginePS.Stop();
        }
        
    }
    private void CheckLimits()
    {
        Vector2 playerPosition = transform.position;

        playerPosition.x = Mathf.Clamp(playerPosition.x,minX,maxX);
        playerPosition.y = Mathf.Clamp(playerPosition.y,minY,maxY);

        transform.position = playerPosition;
    }   
    private void Attack()
    {
        Instantiate(bulletPrefab,shootPoint.position,shootPoint.rotation);  

        AudioManager.AudioInstance.LaserPlayer(); 

        // GameObject bullet = BulletPool.playerBulletInstance.NeedBullet();
        // //bullet.transform.position = shootPoint.position;

        // Vector3 MouseAim = virtualCamera.ScreenToWorldPoint(Input.mousePosition);
        // Vector3 AimDirection = MouseAim - shootPoint.position;
        // bullet.transform.rotation = Quaternion.LookRotation(AimDirection);
    }

    public void ReceiveDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;
        
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        currentHealth = 0;
        healthBar.value = 0;
        this.gameObject.SetActive(false);
        Instantiate(playerDeadFX,transform.position,Quaternion.identity);
        CanvasManager.CanvasInstance.DefeatMenu();
        AudioManager.AudioInstance.PlayerDestroy();
        GameManager.Instance.LoseGame();
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
            maxHealth *= growthHealthUp;
            healthBar.maxValue = maxHealth;
            currentHealth = maxHealth;
        }
        else
        {
            expBar.value = experienceForLevelUp;
            currentHealth = maxHealth;
        }

    }
}