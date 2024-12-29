using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete("This was exchanged for a general Weapon-Display", true)]
public class RangedWeaponDisplay: MonoBehaviour
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
        return weapon.attackSpeed;
    }

    public float GetShootingInterval()
    {
        return 1.0f/weapon.attackSpeed;
    }
}
