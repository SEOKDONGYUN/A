using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip deathClip;
    public Animator animator;

    public int maxHealth = 100;

    int currentHealth;

    private AudioSource playerAudio;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        playerAudio = GetComponent<AudioSource>();
                
    }

    public void TakeDamege(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died!");

        animator.SetTrigger("Die");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        playerAudio.clip = deathClip;
        playerAudio.Play();

        GameManager.instance.AddScore(1);

        Destroy(gameObject, 10f);

        
    }
}