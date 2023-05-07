using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : UnitHealth
{
    Logger logger;

    public override void Die()
    {
        logger = Finder.FindLogger();
        logger.Log("Player '"+this.name+"' dead.", this);
        GameManager.Instance.UpdateGameState(GameState.PlayerDead);
    }
}
