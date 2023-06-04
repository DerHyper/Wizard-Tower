using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    private int damage;
    private int knockback;

    private void Start() {
        damage = GetComponent<MeleeWeaponDisplay>().GetDamage();
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        Debug.Log("TRIGGER");
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().DamageHealth(damage);
            other.GetComponent<Knockback>().Push(gameObject);            
        }
    }
}
