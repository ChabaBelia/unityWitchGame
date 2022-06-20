using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtMonster_Dungeon
{

    public class Projectile : MonoBehaviour
    {
        public float lifeTime = 2.0f;
        public GameObject explosionPrefab;

        float lifeTimer;
        int attackDirection;
        int damage = 10;

        private void Update()
        {
            lifeTimer += Time.deltaTime;
            if ( lifeTimer > lifeTime)
            {
                if (explosionPrefab) Explode();

                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if(collision.tag == "Player") {
                attackDirection = ((collision.gameObject.transform.position.x - gameObject.transform.position.x) > 0) ? 1 : 0;
                collision.gameObject.GetComponent<Player>().TakeDamage(damage, attackDirection);
            }

            if (explosionPrefab)
            {
                Explode();
                Destroy(gameObject);
            }
        }

        private void Explode()
        {
            var explosion = Instantiate(explosionPrefab);
            explosion.transform.position = transform.position;
        }
    }
}
