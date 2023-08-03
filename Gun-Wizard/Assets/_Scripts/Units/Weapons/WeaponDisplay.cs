using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField]
    Weapon weapon;

    public float damageMultiplicator = 0;

    private void Start() 
    {
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        GetComponent<SpriteRenderer>().sprite = weapon.sprite;
    }

    public int GetPlayerDamage()
    {
        return (int) (weapon.damage + weapon.damage * damageMultiplicator);
    }

    public int GetEnemyDamage()
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

    public float GetAttackInterval()
    {
        return 1.0f/weapon.attackSpeed;
    }

    public void SetWeapon(Weapon weapon) {
        this.weapon = weapon;
        UpdateSprite();
    }

    public void SetMultiplicator(float multiplicator){
        damageMultiplicator += multiplicator;
    }

    public GameObject GetBullet()
    {
        return weapon.bullet;
    }
}
