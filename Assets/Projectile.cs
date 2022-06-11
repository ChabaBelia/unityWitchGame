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

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Debug.Log(transform.right.x);
        startPosition = rigidbody.position;
        rigidbody.velocity = projectileSpeed * transform.right;
    }

    void Update()
    {
        if (Math.Abs(startPosition.x - rigidbody.position.x) > projectileDistance) {
            Explode();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if(collision.gameObject.GetComponent<Enemy>()) {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(30);
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
