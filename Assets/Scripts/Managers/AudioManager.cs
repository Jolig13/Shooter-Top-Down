using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager AudioInstance {get; private set;}
    private AudioSource audioSource;
    [SerializeField] private AudioClip playerAttackSound;

    [SerializeField] private AudioClip playerDestroy;
    [SerializeField] private AudioClip enemyDestroy;


    private void Awake() 
    {
        if(AudioInstance==null)
        {
            AudioInstance=this;
            audioSource=GetComponent<AudioSource>();   
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void LaserPlayer()
    {
        audioSource.PlayOneShot(playerAttackSound);
    }

    public void EnemyDestroy()
    {
        audioSource.PlayOneShot(enemyDestroy);
    }

    public void PlayerDestroy()
    {
        audioSource.PlayOneShot(playerDestroy);
    }
} 
