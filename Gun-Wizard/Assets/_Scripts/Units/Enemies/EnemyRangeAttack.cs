using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    private int damage;
    public int knockback {set; get;}
    private float attackInterval = 0.5f;
    private float timeSinceLastShoot;
    private GameObject bullet;
    private WeaponRotationEnemy weaponParent;
    [SerializeField]
    private GameObject firePoint;
    private float shootingInterval;
    private EnemyAI enemyAI;
    private EnemyState state;
    private HashSet<EnemyState> aimStates = new HashSet<EnemyState>() {EnemyState.Hunt, EnemyState.Flee, EnemyState.Stay};
    private bool loaded;
    public float speed;

    void Start()
    {
        StartCoroutine(LateStart(1));
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        UpdateWeapon(); // Needs to be loaded after Weapon Display
        loaded = true;
    }

    void FixedUpdate()
    {
        if (CanShoot() && loaded)
        {
            timeSinceLastShoot = 0;
            ShootBullet();
        }
    }

    private void Awake() {
        enemyAI = GetComponentInParent<EnemyAI>();
        enemyAI.OnEnemyStateChanged += EnemyAIOnGameStateChanged;
    }

    private void OnDestroy() {
        enemyAI.OnEnemyStateChanged -= EnemyAIOnGameStateChanged;
    }

    private void EnemyAIOnGameStateChanged(EnemyState state) {
        this.state = state;
    }

    private void ShootBullet()
    {
        //Debug.Log("Enemy shoots" + bullet);
        MagicBullet magicBullet = Instantiate(
            bullet, 
            firePoint.transform.position, 
            weaponParent.transform.rotation
        ).GetComponent<MagicBullet>();
        
        magicBullet.damage = damage;
        magicBullet.speed = speed;
    }

    private bool CanShoot()
    {
        timeSinceLastShoot += Time.fixedDeltaTime;
        bool canShootAgain = timeSinceLastShoot >= shootingInterval;
        //Debug.Log(aimStates.Contains(state)+ " " + canShootAgain);
        return aimStates.Contains(state) && canShootAgain;
    }

    private void UpdateWeapon()
    {
        WeaponDisplay weaponDisplay = GetComponentInChildren<WeaponDisplay>();
        knockback = weaponDisplay.GetKnockback();
        attackInterval = weaponDisplay.GetAttackInterval();
        damage = weaponDisplay.GetEnemyDamage();
        bullet = weaponDisplay.GetBullet();
        speed = weaponDisplay.GetBulletSpeed();
        shootingInterval = weaponDisplay.GetAttackInterval();
        weaponParent = GetComponentInChildren<WeaponRotationEnemy>();
    }

    private void HitPlayer()
    {
        GameObject player = Finder.FindPlayer();
        player.GetComponent<PlayerHealth>().DamageHealth(damage);
        player.GetComponent<Knockback>().Push(gameObject, knockback);    
    }
}
