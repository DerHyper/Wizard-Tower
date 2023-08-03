using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    [SerializeField]
    float damageMultiplicator;
    [SerializeField]
    float attackSpeedMultiplicator;

    WeaponDisplay weaponDisplay;

    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        weaponDisplay = Finder.FindPlayerGun();
        
    }

    public void SetDamageMultiplicator(float amount)
    {
        damageMultiplicator = amount;
    }
    public void SetAttackSpeedMultiplicator(float amount)
    {
        attackSpeedMultiplicator = amount;
    }

    public float GetDamageMultiplicator()
    {
        return damageMultiplicator;
    }

    public float GetAttackSpeedMultiplicator()
    {
        return attackSpeedMultiplicator;
    }
}
