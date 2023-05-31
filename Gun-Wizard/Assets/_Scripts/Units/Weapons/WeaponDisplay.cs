using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WeaponDisplay
{
    private void Start()
    {
        SetSprite();
    }
    public void SetSprite();
    public int GetDamage();

}
