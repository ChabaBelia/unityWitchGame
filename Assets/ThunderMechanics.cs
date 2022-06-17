using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderMechanics : MonoBehaviour
{
    public int damage = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if(collision.gameObject.GetComponent<Enemy>()) {
                collision.gameObject.GetComponent<Enemy>().TakeElectricityDamage(50);
            }
            Destroy(gameObject);
        }
    }
}
