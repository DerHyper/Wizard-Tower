using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : Bullet
{
    int damage;
    int speed;
    Gun gun;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            gun = GameObject.FindGameObjectWithTag("Player").GetComponent<Gun>();
            damage = gun.GetDamage();
            speed = gun.GetSpeed();
        }
        catch (System.Exception)
        {
            damage = 20;
            speed = 20;
        }
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

}
