using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyScript : MonoBehaviour, IDamageReceive
{   
    private Rigidbody2D rb2D;
    private Transform target;
    [SerializeField] private float speedMove;
    [SerializeField] private ParticleSystem shipDestroyed;

    [SerializeField] private int damage = 10;
    [SerializeField] private GameObject expItem;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (target != null)
        {
            Follow();
        }
    }

    private void Follow()
    {
        Vector2 direction = (target.position-transform.position).normalized;
        rb2D.MovePosition(rb2D.position+direction*speedMove*Time.deltaTime);
        
        float angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg-90f;
        rb2D.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.CompareTag("Player"))
        {   
            IDamageReceive player = other.gameObject.GetComponent<IDamageReceive>();
            {
                if(player != null)
                {
                    player.ReceiveDamage(damage);
                }
            }
            DeathFX();
            //Instantiate(shipDestroyed,transform.position,Quaternion.identity); 
            this.gameObject.SetActive(false);
          
        } 
        if(other.gameObject.CompareTag("playerBullet"))
        {   
            ReceiveDamage();
            //Instantiate(shipDestroyed,transform.position,Quaternion.identity);    
            Destroy(other.gameObject);
            //Destroy(this.gameObject); 
            //gameObject.SetActive(false);
            //other.gameObject.SetActive(false);
            Instantiate(expItem,transform.position,Quaternion.identity);
        }    

    }
    public void DeathFX()
    {
        Instantiate(shipDestroyed,transform.position,Quaternion.identity);
        AudioManager.AudioInstance.EnemyDestroy();
    }
    public void ReceiveDamage()
    {
        DeathFX();
        this.gameObject.SetActive(false);
        GameManager.Instance.Score();
    }
}   
