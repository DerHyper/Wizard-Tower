using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieHealth : MonoBehaviour
{
    private int totalHealth;
    private int currenHealth;
    Logger logger;

    private void Start() {
        totalHealth = 30;
        currenHealth = 30;
        logger = Finder.FindLogger();
    }

    public void DamageHealth(int damage)
    {
        if (currenHealth-damage > 0)
        {
            currenHealth -= damage;
        }
        else if (currenHealth-damage < 0)
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
}
