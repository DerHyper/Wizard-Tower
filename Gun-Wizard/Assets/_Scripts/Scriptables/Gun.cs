using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Gun", menuName = "ScriptableObject/Gun")]
public class Gun : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite sprite;
    public int damage;
    public int bulletSpeed;
    public int shootingSpeed;
}
