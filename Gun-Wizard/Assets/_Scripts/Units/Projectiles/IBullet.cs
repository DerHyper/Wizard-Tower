using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface for Bullets
public abstract class IBullet : MonoBehaviour
{
    int damage;
    int speed;
    GunDisplay gunDisplay;
}
