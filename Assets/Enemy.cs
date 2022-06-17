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

    public int maxHealth = 200;
    int currentHealth;

    int damage = 5;
    bool is_attacking = false;
    bool is_dead = false;
    float attackDirection;

    int attak_interval = 125;
    int burn_interval = 75;
    bool is_burning;
    SpriteRenderer smoke;

    int burning_damage = 10;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
         
        SpriteRenderer[] allChildren = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer child in allChildren)
        {
            if(child.tag == "Smoke") {
                smoke = child;
                break;
            }
        }

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

        if (is_burning && Time.frameCount % burn_interval == 0) {
            DecreaseHealth(burning_damage);
        }
        
        attackDirection = ((player.transform.position.x - gameObject.transform.position.x) > 0) ? 1 : 0;
        if(attackDirection > 0) {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        } else {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        if (is_attacking && Time.frameCount % attak_interval == 0) {
            player.GetComponent<Player>().TakeDamage(damage, attackDirection);
        }
    }

    public void TakeDamage(int damage) 
    {
        animator.SetTrigger("Hurt");
        DecreaseHealth(damage);
    }

    public void TakeElectricityDamage(int damage) {
        clearAllEffects();
        animator.SetTrigger("HurtByElectricity");
        DecreaseHealth(damage);
    }

    public void TakeFireDamage(int damage) {
        clearAllEffects();
        DecreaseHealth(damage);
        //TODO: ClearOtherEffects();
        smoke.enabled = true;
        StartCoroutine(Burn(5));
        
    }

    public void DecreaseHealth(int points) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0) Die();
    }

    public void Die() {
        clearAllEffects();
        animator.SetBool("IsDead", true);
        is_dead = true;
        aiPath.enabled = false;
        healthBar.enabled = false;
        GetComponentsInChildren<Canvas>()[0].enabled = false;
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(Disappear(5));
    }

    public void clearAllEffects() {
        is_burning = false;
    }

    IEnumerator Burn(float time) {
        is_burning = true;
        yield return new WaitForSeconds(time);
        is_burning = false;
        smoke.enabled = false;
    }

    IEnumerator Disappear(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    } 
}
