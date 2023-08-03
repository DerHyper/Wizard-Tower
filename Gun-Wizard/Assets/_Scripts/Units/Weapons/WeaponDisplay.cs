using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField]
    Weapon weapon;
    [SerializeField]
    private float damageMultiplicator;
    [SerializeField]
    private float attackSpeedMultiplicator;

    private void Start() 
    {
        UpdateSprite();
        damageMultiplicator = PlayerStats.Instance.GetDamageMultiplicator();
        attackSpeedMultiplicator = PlayerStats.Instance.GetAttackSpeedMultiplicator();
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
        return weapon.attackSpeed + weapon.attackSpeed * attackSpeedMultiplicator;
    }

    public float GetAttackInterval()
    {
        Debug.Log("Attack Speed: " + weapon.attackSpeed);
        return 1.0f/GetAttackSpeed();
    }

    public void SetWeapon(Weapon weapon) {
        this.weapon = weapon;
        UpdateSprite();
    }

    public GameObject GetBullet()
    {
        return weapon.bullet;
    }
}
