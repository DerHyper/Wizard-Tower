using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete("This was exchanged for a general Weapon-Display", true)]
public class MeleeWeaponDisplay: MonoBehaviour
{

    [SerializeField]
    MeleeWeapon weapon;

    private void Start() 
    {
        SetSprite();
        GetComponent<EnemyMeleeAttack>().knockback = weapon.knockback;
    }

    public void SetSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = weapon.sprite;
    }

    public int GetDamage()
    {
        return weapon.damage;
    }

    public int GetKnockback()
    {
        return weapon.knockback;
    }
}
