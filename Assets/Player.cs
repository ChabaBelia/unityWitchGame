using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;

    public int maxMana = 100;
    public int currentMana;

    public HealthBar healthBar;
    public ManaBar manaBar;

    int mana_recovery_interval = 125;
    int health_recovery_interval = 300;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;

        healthBar.SetMaxHealth(maxHealth);
        manaBar.SetMaxMana(maxMana);
    }

    // Update is called once per frame
    void Update()
    {   
        if(currentMana < maxMana && Time.frameCount % mana_recovery_interval == 0) {
           addMana(1);
        }
        if(currentHealth < maxHealth && Time.frameCount % health_recovery_interval == 0) {
            addHealth(1);
        }
    }

    public void addMana(int points) {
        currentMana += points;
        manaBar.SetMana(currentMana);
    }

    public void addHealth(int points) {
        currentHealth += points;
        healthBar.SetHealth(currentHealth);
    }

    public void UseMana(int points) {
        currentMana -= points;
        manaBar.SetMana(currentMana);
    }

    public void TakeDamage(int damage, float attackDirection) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("Hurt");
        animator.SetFloat("AttackDirection", attackDirection);
    }
}
