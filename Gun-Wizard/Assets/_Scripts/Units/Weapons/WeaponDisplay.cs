using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField]
    Weapon weapon;

    private void Start() 
    {
        SetSprite();
    }

    public void SetSprite()
    {
        GetComponent<SpriteRenderer>().sprite = weapon.sprite;
    }

    public int GetDamage()
    {
        return weapon.damage;
    }

    public int GetKnockback()
    {
        return weapon.knockback;
    }

    // Get the speed the Bullet is traveling
    public float GetBulletSpeed()
    {
        return weapon.bulletSpeed;
    }

    // Get ShootingSpeed in Bullets per second 
    public float GetAttackSpeed()
    {
        return weapon.attackSpeed;
    }

    public float GetShootingInterval()
    {
        return 1.0f/weapon.attackSpeed;
    }

}
