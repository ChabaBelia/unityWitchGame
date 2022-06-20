using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Cainos.PixelArtMonster_Dungeon;

public class Enemy : MonoBehaviour
{
    public HealthBar healthBar;
    public Animator animator;

    public int maxHealth = 200;
    int currentHealth;

    int damage = 10;
    bool is_dead = false;

    int burn_interval = 75;
    bool is_burning;
    SpriteRenderer smoke;
    Vector3 initial_transform;
    int burning_damage = 10;
    int attackDirection;
    bool is_attacking = false;
    PixelMonster pm;
    AIPath aiPath;
    GameObject player;
    bool colliding_player = false;

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        initial_transform = transform.localScale;
         
        SpriteRenderer[] allChildren = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer child in allChildren)
        {
            if(child.tag == "Smoke") {
                smoke = child;
                break;
            }
        }
        pm = GetComponent<PixelMonster>();
        aiPath = GetComponent<AIPath>();
    }

    void Update() {
        if(is_dead) return;

        if (is_burning && Time.frameCount % burn_interval == 0) {
            DecreaseHealth(burning_damage);
        }

        attackDirection = ((player.transform.position.x - gameObject.transform.position.x) > 0) ? 1 : -1;
        pm.Facing = attackDirection;

        if(aiPath.desiredVelocity.x >= 0.01f || aiPath.desiredVelocity.x <= -0.01f) {
            pm.MovingBlend = 0.05f;
            is_attacking = false;
        } else {
            pm.MovingBlend = 0.0f;
            is_attacking = true;
        }

        if (is_attacking && !pm.IsAttacking) {
            pm.Attack();
        }
    }

    public void hitPlayer() {
        if(colliding_player) {
            attackDirection = ((player.transform.position.x - gameObject.transform.position.x) > 0) ? 1 : 0;
            player.GetComponent<Player>().TakeDamage(damage, attackDirection);
        }
    }

    public void TakeDamage(int damage, Vector3 projectile_rotation) 
    {
        if(pm.Facing == -1 && projectile_rotation.z == 180
            || pm.Facing == 1 && projectile_rotation.z == 0
        ) {
             animator.SetTrigger("InjuredBack");
        } else {
            animator.SetTrigger("InjuredFront");
        }
       
        DecreaseHealth(damage);
    }

    public void TakeElectricityDamage(int damage) {
         // TODO: calc front and back
        clearAllEffects();
        animator.SetTrigger("InjuredFront");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
       if (collision.tag == "Player")
       {
           colliding_player = true;
       }
   }

    private void OnTriggerExit2D(Collider2D collision)
    {
          Debug.Log("Exit");
        if (collision.tag == "Player")
        {
            colliding_player = false;
        }
    }
}
