using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Unit", menuName = "ScriptableObject/Unit")]
public class Unit : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite artwork;
    public float movementSpeed;
    public int maxHealth;
    public Weapon weapon;
    public int amountOfMoney;
    public MovementBehaviour behaviour = MovementBehaviour.Aggressive; 
}

public enum MovementBehaviour {
    Player,
    Aggressive,
    Distancing
}
