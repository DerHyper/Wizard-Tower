using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    private InputManager inputManager;
    private Vector2 PointerPosition;
    private Vector2 OriginalWeaponScale;
    private void Start() 
    {
        inputManager = Finder.FindInputManager();
        OriginalWeaponScale = transform.localScale;
    }

    void Update()
    {
        LookAtPointer();
    }

    private void LookAtPointer()
    {
        PointerPosition = inputManager.GetShootVektor();
        Vector2 direktion = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direktion;
        FlipWeaponIfLookingBackwards(direktion);
        FlipPlayerIfLookingBackwards(direktion);
    }

    private void FlipPlayerIfLookingBackwards(Vector2 direktion)
    {
        SpriteRenderer player = GetComponentInParent<SpriteRenderer>();
        if (direktion.x < 0)
        {
            player.flipX = true;
        }
        else
        {
            player.flipX = false;
        }
    }

    private void FlipWeaponIfLookingBackwards(Vector2 direktion)
    {
        Vector2 newWeaponScale = transform.localScale;
        if (direktion.x < 0)
        {
            newWeaponScale.y = -OriginalWeaponScale.y;
        }
        else
        {
            newWeaponScale.y = OriginalWeaponScale.y;
        }
        transform.localScale = newWeaponScale;
    }
}
