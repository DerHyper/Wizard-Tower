using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : IBullet
{
    [HideInInspector]
    public int damage;
    [HideInInspector]
    public float speed;
    private Logger logger;
    private Rigidbody2D rb;

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
