using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    SpriteRenderer barrier;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;

        healthBar.SetMaxHealth(maxHealth);
        manaBar.SetMaxMana(maxMana);

        SpriteRenderer[] allChildren = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer child in allChildren)
        {
            if(child.tag == "MagicBarrier") {
                barrier = child;
                break;
            }
        }
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

    public void TakeDamage(int damage, int attackDirection) {
        if(barrier.enabled) {
            damage = damage % 2;
        }
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("Hurt");
        animator.SetFloat("AttackDirection", attackDirection);
        if(currentHealth <= 0) {
            animator.SetBool("isDead", true);
        }
    }
    
    public void EnableBarrier(int seconds) {
        barrier.enabled = true;
        StartCoroutine(DisableBarrier(seconds));
    }
    
    IEnumerator DisableBarrier(float time)
    {
        yield return new WaitForSeconds(time);
        barrier.enabled = false;
    } 

    public void Dissapear() {
        SceneManager.LoadScene("SampleScene");
    }
}
