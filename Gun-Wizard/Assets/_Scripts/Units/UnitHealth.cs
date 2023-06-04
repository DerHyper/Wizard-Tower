using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour, IUnitHealth
{
    [SerializeField]
    private Unit unit;
    [SerializeField]
    private float timeout;
    private bool isInTimeout = false;
    private int maxHealth;
    private int currenHealth;
    Logger logger;

    public void Start() {
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
        if (isInTimeout)
        {
            return;
        }
        
        logger.Log("Unit '"+this.name+"' , "+currenHealth+", -"+amount, this);
        if (currenHealth-amount > 0)
        {
            currenHealth -= amount;
        }
        else if (currenHealth-amount <= 0)
        {
            currenHealth = 0;
            Die();
        }

        StartTimeout();
    }

    private void StartTimeout()
    {
        isInTimeout = true;
        logger.Log(name+" is in Timeout.",this);
        Invoke("StopTimeout", timeout);
    }

    private void StopTimeout()
    {
        isInTimeout = false;
    }

    public virtual void Die()
    {
        logger.Log("Unit '"+this.name+"' dead.", this);
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
