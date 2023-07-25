using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDisplay : MonoBehaviour
{
    [SerializeField]
    private Unit unit;

    void Start()
    {
        GetComponent<UnitHealth>().SetUnit(unit);
        GetComponent<SpriteRenderer>().sprite = unit.artwork;
        GetComponentInChildren<WeaponDisplay>().SetWeapon(unit.weapon);
    }

    public float GetMovementSpeed() {
        return unit.movementSpeed;
    }
}
