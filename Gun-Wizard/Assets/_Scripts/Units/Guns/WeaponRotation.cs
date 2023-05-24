using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    private InputManager inputManager;
    private Vector2 PointerPosition;
    private Vector2 OriginalWeaponScale;
    private SpriteRenderer playerSprite;
    private SpriteRenderer weaponSprite;

    private void Start() 
    {
        inputManager = Finder.FindInputManager();
        //Expects that Parent-GO has Player-Sprite
        playerSprite = transform.parent.GetComponent<SpriteRenderer>();
        weaponSprite = GetComponentInChildren<SpriteRenderer>();
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
        FlipWeaponIfLookingBackwards();
        FlipPlayerIfLookingBackwards();
        ChangeLayerIfBehindPlayer();
    }

    private void ChangeLayerIfBehindPlayer()
    {
        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            weaponSprite.sortingOrder = playerSprite.sortingOrder-1;
        }
        else
        {
            weaponSprite.sortingOrder = playerSprite.sortingOrder+1;
        }
    }

    private void FlipPlayerIfLookingBackwards()
    {
        if (transform.right.x < 0)
        {
            playerSprite.flipX = true;
        }
        else
        {
            playerSprite.flipX = false;
        }
    }

    private void FlipWeaponIfLookingBackwards()
    {
        Vector2 newWeaponScale = transform.localScale;
        if (transform.right.x < 0)
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
