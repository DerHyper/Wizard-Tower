using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Gun")]
public class Gun : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite artwork;
    public int damage;
    public int bulletSpeed;
    public int shootingSpeed;
}
