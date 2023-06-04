using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    private float GetKnockback(GameObject sender)
    {
        float knockback = sender.GetComponent<MeleeWeaponDisplay>().GetKnockback();
        return knockback;
    }
    public void Push(GameObject sender)
    {
        float knockback = GetKnockback(sender);
        Vector2 forceDirection = (transform.position - sender.transform.position).normalized;
        GetComponent<Rigidbody2D>().AddForce(forceDirection*knockback*100, ForceMode2D.Force);
    }
}
