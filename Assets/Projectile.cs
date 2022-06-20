using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    public float projectileDistance;
    public GameObject impactEffect;
    private Rigidbody2D rigidbody;
    private Vector2 startPosition;
    public int damage = 30;
    public string damageType = "None";

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        startPosition = rigidbody.position;
        rigidbody.velocity = projectileSpeed * transform.right;
    }

    void Update()
    {
        if (Math.Abs(startPosition.x - rigidbody.position.x) > projectileDistance) {
            Explode();
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if(enemy && damageType == "None") {
                enemy.TakeDamage(damage, transform.eulerAngles);
            } else if (enemy && damageType == "Fire") {
                enemy.TakeFireDamage(damage);
            }
            Explode();
        }
    }

    private void Explode() 
    {
        if(impactEffect){
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
