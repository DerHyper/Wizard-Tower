using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    private int damage;
    public int knockback {set; get;}
    private float swingingTime = 0.5f;
    private bool playerInRange = false;
    private bool isSwinging = false;
    
    private void Start() {
        WeaponDisplay weaponDisplay = GetComponent<WeaponDisplay>();
        damage = weaponDisplay.GetDamage();
        knockback = weaponDisplay.GetKnockback();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player")
        {
            playerInRange = true;
            if (!isSwinging)
            {
                //Start swinging here
                isSwinging = true;
                Invoke("TryHitPlayer", swingingTime);  
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player")
        {
            playerInRange = false;  
        }
    }

    private void TryHitPlayer()
    {
        if (playerInRange)
        {
            HitPlayer();
        } else {
            //miss
        }

        isSwinging = false;
    }

    private void HitPlayer()
    {
        GameObject player = Finder.FindPlayer();
        player.GetComponent<PlayerHealth>().DamageHealth(damage);
        player.GetComponent<Knockback>().Push(gameObject, knockback);    
    }
}
