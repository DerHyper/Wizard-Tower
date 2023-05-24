using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDisplay: MonoBehaviour
{
    [SerializeField]
    Gun gun;

    private void Start() 
    {
        SetSprite();
    }

    private void SetSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = gun.sprite;
    }

    public int GetDamage()
    {
        return gun.damage;
    }

    // Get the speed the Bullet is traveling
    public int GetBulletSpeed()
    {
        return gun.bulletSpeed;
    }

    // Get ShootingSpeed in Bullets per second 
    public int GetShootingSpeed()
    {
        return gun.shootingSpeed;
    }

    public float GetShootingInterval()
    {
        return 1.0f/gun.shootingSpeed;
    }
}
