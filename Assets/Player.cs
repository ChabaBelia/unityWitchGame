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
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            UseMana(10);
        }
    }

    public void addMana(int points) {
        Debug.Log("Current Mana " + currentMana);
        Debug.Log("addMana " + points);
        currentMana += points;
        Debug.Log("Current Mana " + currentMana);
        manaBar.SetMana(currentMana);
    }

    public void addHealth(int points) {
        Debug.Log("addHealth " + points);
        currentHealth += points;
        healthBar.SetHealth(currentHealth);
    }

    void UseMana(int points) {
        Debug.Log("Use Mana " + points);
        currentMana -= points;
        Debug.Log("Current Mana " + currentMana);
        manaBar.SetMana(currentMana);
    }

    public void TakeDamage(int damage, float attackDirection) {
        Debug.Log("TakeDamage " + damage);
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("Hurt");
        animator.SetFloat("AttackDirection", attackDirection);
    }
}
