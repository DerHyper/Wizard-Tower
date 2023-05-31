using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Weapon", menuName = "ScriptableObject/Weapon/Weapon")]
public class Weapon : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite sprite;
    public int damage;
    public int knockback;
}