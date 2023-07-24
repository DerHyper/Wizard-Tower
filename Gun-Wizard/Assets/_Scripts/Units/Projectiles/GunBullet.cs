using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : IBullet
{
    int damage;
    int speed;
    WeaponDisplay gun;
    Rigidbody2D rb;
    Logger logger;
    
    void Start()
    {
        UpdateInstances();
    }

    private void UpdateInstances() 
    {
        gun = Finder.FindPlayerGun();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * gun.GetBulletSpeed();
        logger = Finder.FindLogger();
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemieHealth>()?.DamageHealth(gun.GetDamage());
            logger.Log("Damage on'"+other.name+"'.", this);
            Destroy(gameObject);
        }
        else if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
