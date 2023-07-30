using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : IBullet
{
    [HideInInspector]
    public int damage;
    [HideInInspector]
    public float speed;
    private Rigidbody2D rb;
    private Logger logger;
    
    void Start()
    {
        UpdateInstances();
        rb.velocity = transform.right * speed;
    }

    private void UpdateInstances() 
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        logger = Finder.FindLogger();
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemieHealth>()?.DamageHealth(damage);
            logger.Log("Damage on'"+other.name+"'.", this);
            Destroy(gameObject);
        }
        else if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
