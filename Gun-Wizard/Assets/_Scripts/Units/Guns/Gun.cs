using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Header("Gun Settings")]
    int damage = 20;
    [SerializeField]
    int bulletSpeed = 20;
    [SerializeField]
    int shootingSpeed = 20;

    public int GetDamage()
    {
        return damage;
    }

    // Get the speed the Bullet is traveling
    public int GetBulletSpeed()
    {
        return bulletSpeed;
    }

    // Get ShootingSpeed in Bullets per second 
    public int GetShootingSpeed()
    {
        return shootingSpeed;
    }
}
