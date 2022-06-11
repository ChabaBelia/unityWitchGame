using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public HealthBar healthBar;
    public Animator animator;
    public GameObject player;
    public AIPath aiPath;

    public int maxHealth = 100;
    int currentHealth;

    int damage = 5;
    bool is_attacking = false;
    bool is_dead = false;
    float attackDirection;

    private int interval = 125;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            is_attacking = true;
            animator.SetBool("Attack", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           is_attacking = false;
           animator.SetBool("Attack", false);
        }
    }

    void Update() {
        if(is_dead) return;
        
        attackDirection = ((player.transform.position.x - gameObject.transform.position.x) > 0) ? 1 : 0;
        if(attackDirection > 0) {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        } else {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        if (is_attacking && Time.frameCount % interval == 0) {
            player.GetComponent<Player>().TakeDamage(damage, attackDirection);
        }
    }

    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0) 
        {
            animator.SetBool("IsDead", true);
            is_dead = true;
            aiPath.enabled = false;
            healthBar.enabled = false;
            GetComponentsInChildren<Canvas>()[0].enabled = false;
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(Disappear(5));
        }
    }


    IEnumerator Disappear(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    } 
}
