using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour, IUnitHealth
{
    [SerializeField]
    private Unit unit;
    private int maxHealth;
    private int currenHealth;
    Logger logger;

    private void Start() {
        SetHealthToUnitStandart();
        logger = Finder.FindLogger();
    }

    // Sets all stats to the SO standart
    private void SetHealthToUnitStandart()
    {
        maxHealth = unit.maxHealth;
        currenHealth = maxHealth;
    }


    public void DamageHealth(int amount)
    {
        if (currenHealth-amount > 0)
        {
            currenHealth -= amount;
        }
        else if (currenHealth-amount < 0)
        {
            currenHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        logger.Log("Enemy '"+this.name+"' dead.", this);
        Destroy(gameObject);
    }

    public void HealHealth(int amount)
    {
        if (currenHealth+amount > maxHealth)
        {
            currenHealth = maxHealth;
        }
        else
        {
            currenHealth += amount;
        }
    }
}
