using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    float damageMultiplicator;
    WeaponDisplay weaponDisplay;

    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        weaponDisplay = Finder.FindPlayerGun();
    }

    public void SetDamageMultiplicator(float amount)
    {
        damageMultiplicator = amount;
        weaponDisplay.SetMultiplicator(amount);
    }
}
