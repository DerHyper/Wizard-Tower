using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : IBullet
{
    int damage;
    int speed;
    GunDisplay gun;
    Rigidbody2D rb;
    Logger logger;
    
    void Start()
    {
        UpdateInstances();
    }

    private void UpdateInstances() 
    {
        gun = GameObject.FindGameObjectWithTag("Player").GetComponent<GunDisplay>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * gun.GetBulletSpeed();
        logger = GameObject.FindObjectOfType<Logger>();
    }

    private void OnTriggerEnter2D(Collider2D other) {

        other.GetComponent<EnemieHealth>()?.DamageHealth(gun.GetDamage());
        logger.Log("Damage on'"+other.name+"'.", this);

        Destroy(gameObject);
    }
}
