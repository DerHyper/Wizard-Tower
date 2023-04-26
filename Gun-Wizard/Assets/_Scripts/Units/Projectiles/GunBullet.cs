using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : IBullet
{
    int damage;
    int speed;
    Gun gun;
    Rigidbody2D rb;
    Logger logger;
    
    void Start()
    {
        GetGunAttributes();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        logger = GameObject.FindObjectOfType<Logger>();
    }

    private void GetGunAttributes() 
    {
        try
        {
            gun = GameObject.FindGameObjectWithTag("Player").GetComponent<Gun>();
            damage = gun.GetDamage();
            speed = gun.GetBulletSpeed();
        }
        catch (System.Exception)
        {
            Debug.Log("No Gun found");
            damage = 20;
            speed = 20;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.name);
        
        try
        {
            other.GetComponent<EnemieHealth>().DamageHealth(damage);
            Debug.Log("Damage on'"+other.name+"'.", this);
        }
        catch (System.Exception)
        {
            Debug.Log("No Health-Script found for '"+other.name+"'.", this);
        }
    }
}
