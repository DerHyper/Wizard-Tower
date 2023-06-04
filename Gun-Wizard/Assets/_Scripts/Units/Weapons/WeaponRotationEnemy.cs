using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotationEnemy : MonoBehaviour
{
    private InputManager inputManager;
    private Vector2 PointerPosition;
    private Vector2 OriginalWeaponScale;
    private SpriteRenderer EnemySprite;
    private SpriteRenderer weaponSprite;
    private GameObject Player;

    private void Start() 
    {
        //Expects that Parent-GO has Enemy-Sprite
        EnemySprite = transform.parent.GetComponent<SpriteRenderer>();
        weaponSprite = GetComponentInChildren<SpriteRenderer>();
        OriginalWeaponScale = transform.localScale;
        Player = Finder.FindPlayer();
    }

    void Update()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        Vector2 playerPosition = Player.transform.position;
        Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;
        FlipWeaponIfLookingBackwards();
        FlipPlayerIfLookingBackwards();
        ChangeLayerIfBehindPlayer();
    }

    private void ChangeLayerIfBehindPlayer()
    {
        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            weaponSprite.sortingOrder = EnemySprite.sortingOrder-1;
        }
        else
        {
            weaponSprite.sortingOrder = EnemySprite.sortingOrder+1;
        }
    }

    private void FlipPlayerIfLookingBackwards()
    {
        if (transform.right.x < 0)
        {
            EnemySprite.flipX = true;
        }
        else
        {
            EnemySprite.flipX = false;
        }
    }

    private void FlipWeaponIfLookingBackwards()
    {
        if (transform.right.x < 0)
        {
            weaponSprite.flipY = true;
        }
        else if (transform.right.x > 0)
        {
            weaponSprite.flipY = false;
        }
    }
}
