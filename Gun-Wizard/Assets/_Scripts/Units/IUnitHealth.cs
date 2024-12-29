using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitHealth
{
    // Adds the given amount to the current Health
    public void HealHealth(int amount);
    
    // Substracts the given amount from the current Health (can kill)
    public void DamageHealth(int amount);

    // Lets the Unit die
    private void Die(){}
}
