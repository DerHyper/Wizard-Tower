using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : IBullet
{
    public int damage;
    public float speed;
    Logger logger;
    Rigidbody2D rb;

    private void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        logger = Finder.FindLogger();
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>()?.DamageHealth(damage);
            logger.Log("Damage on Player.", this);
            Destroy(gameObject);
        }
        else if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
