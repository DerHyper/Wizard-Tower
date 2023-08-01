using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    Transform firePoint;

    [SerializeField]
    Logger logger;
    
    private GameObject bullet;
    public InputManager inputManager;
    private WeaponDisplay weaponDisplay;
    private WeaponRotation weaponParent;
    private float shootingInterval;
    private float timeSinceLastShoot;
    private bool isPlaying = true;

    private void Awake() {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void OnDestroy() {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state) {
        isPlaying = (state == GameState.Playing || state == GameState.LevelComplete);
    }

    void FixedUpdate()
    {
        Debug.Log(isPlaying);
        if (CanShoot())
        {
            timeSinceLastShoot = 0;
            ShootBullet();
        }
    }

    void Start()
    {
        UpdateInstances();
    }

    // Updates all Class-Instances to the current ones in use
    private void UpdateInstances()
    {
        weaponDisplay = Finder.FindPlayerGun();
        shootingInterval = weaponDisplay.GetAttackInterval();
        inputManager = Finder.FindInputManager();
        logger = Finder.FindLogger();
        weaponParent = GetComponentInChildren<WeaponRotation>();
        bullet = weaponDisplay.GetBullet();
    }

    // Spawns a Bullet with the attributes of the Gun equipped.
    private void ShootBullet()
    {
        //logger.Log("FIRE!",this);

        GunBullet gunBullet = Instantiate(
            bullet, 
            firePoint.transform.position, 
            weaponParent.transform.rotation
        ).GetComponent<GunBullet>();

        gunBullet.damage = weaponDisplay.GetDamage();
        gunBullet.speed = weaponDisplay.GetBulletSpeed();

    }
    
    // returns true if Player can shoot again
    private bool CanShoot()
    {
        timeSinceLastShoot += Time.fixedDeltaTime;
        bool canShootAgain = timeSinceLastShoot >= shootingInterval;
        return isPlaying && inputManager.ShootButtonPressed() && canShootAgain;
    }
}
