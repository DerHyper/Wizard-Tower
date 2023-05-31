using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="RangedWeapon", menuName = "ScriptableObject/Weapon/RangedWeapon")]
public class RangedWeapon : Weapon
{
    public Sprite bulletsprite;
    public float bulletSpeed;
    public float shootingSpeed;
}
