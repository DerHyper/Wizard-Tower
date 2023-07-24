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
    
    [SerializeField]
    GameObject bullet;

    public InputManager inputManager;
    private WeaponDisplay weaponDisplay;
    private WeaponRotation weaponParent;
    private float shootingInterval;
    private float timeSinceLastShoot;
    private bool isPlaying;

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
        shootingInterval = weaponDisplay.GetShootingInterval();
        inputManager = Finder.FindInputManager();
        logger = Finder.FindLogger();
        weaponParent = GetComponentInChildren<WeaponRotation>();
    }

    // Spawns a Bullet with the attributes of the Gun equipped.
    private void ShootBullet()
    {
        logger.Log("FIRE!",this);

        Instantiate(
            bullet, 
            firePoint.transform.position, 
            weaponParent.transform.rotation
        );
    }
    
    // returns true if Player can shoot again
    private bool CanShoot()
    {
        timeSinceLastShoot += Time.fixedDeltaTime;
        bool canShootAgain = timeSinceLastShoot >= shootingInterval;
        logger.Log(shootingInterval, this);
        return isPlaying && inputManager.ShootButtonPressed() && canShootAgain;
    }
}
