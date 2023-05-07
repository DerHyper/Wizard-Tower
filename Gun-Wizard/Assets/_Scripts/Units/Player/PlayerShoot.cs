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
    private GunDisplay gunDisplay;
    private float shootingInterval;
    private float timeSinceLastShoot;

    void FixedUpdate()
    {
        if (inputManager.GetIsShooting() && GetCanShootAgain())
        {
            timeSinceLastShoot=0;
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
        gunDisplay = Finder.FindPlayerGun();
        shootingInterval = gunDisplay.GetShootingInterval();
        inputManager = Finder.FindInputManager();
        logger = Finder.FindLogger();
    }

    // Spawns a Bullet with the attributes of the Gun equipped.
    private void ShootBullet()
    {
        logger.Log("FIRE!",this);

        Instantiate(
            bullet, 
            firePoint.transform.position, 
            inputManager.GetShootQuaternion()
        );
    }
    
    // returns true if Player can shoot again
    private bool GetCanShootAgain()
    {
        timeSinceLastShoot += Time.fixedDeltaTime;
        return timeSinceLastShoot >= shootingInterval;
    }
}
