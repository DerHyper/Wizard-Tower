using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeaponDisplay: MonoBehaviour, WeaponDisplay
{

    [SerializeField]
    RangedWeapon weapon;

    public void SetSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = weapon.sprite;
    }

    public int GetDamage()
    {
        return weapon.damage;
    }

    // Get the speed the Bullet is traveling
    public float GetBulletSpeed()
    {
        return weapon.bulletSpeed;
    }

    // Get ShootingSpeed in Bullets per second 
    public float GetShootingSpeed()
    {
        return weapon.shootingSpeed;
    }

    public float GetShootingInterval()
    {
        return 1.0f/weapon.shootingSpeed;
    }
}
