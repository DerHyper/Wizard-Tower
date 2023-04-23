using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : IBullet
{
    int damage;
    int speed;
    Gun gun;
    Rigidbody2D rb;
    
    void Start()
    {
        GetGunAttributes();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
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
            damage = 20;
            speed = 20;
        }
    }
}
