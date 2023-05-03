using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : UnitHealth
{
    Logger logger;

    public new void Die()
    {
        logger = Finder.FindLogger();
        logger.Log("Player '"+this.name+"' dead.", this);
        Destroy(gameObject);
    }
}
