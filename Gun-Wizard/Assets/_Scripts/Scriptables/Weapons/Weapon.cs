using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Weapon", menuName = "ScriptableObject/Weapon/Weapon")]
public class Weapon : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite sprite;
    [Range(0,100)]
    public int damage;
    [Range(0,100)]
    public int knockback;
    // Time between attacks
    [Range(0.1f,100)]
    public float attackSpeed;
    public Weapontype weapontype;
    [Header("Ranged-Weapon attributes")]
    public Sprite bulletsprite;
    [Range(0.1f,100)]
    public float bulletSpeed;
    public GameObject bullet;
    
}

public enum Weapontype{
    melee,
    ranged
}