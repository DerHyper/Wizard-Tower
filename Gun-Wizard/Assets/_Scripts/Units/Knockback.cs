using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    float KnockbackTime = 0.15f; 
    GameState oldState;
    public void Push(GameObject sender, float knockback)
    {
        Debug.Log("Push Player by " + knockback);
        Vector2 forceDirection = (transform.position - sender.transform.position).normalized;
        GetComponent<Rigidbody2D>().AddForce(forceDirection*knockback*100, ForceMode2D.Force);
        Invoke("StopKnockback", KnockbackTime);
    }

    private void StopKnockback()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
