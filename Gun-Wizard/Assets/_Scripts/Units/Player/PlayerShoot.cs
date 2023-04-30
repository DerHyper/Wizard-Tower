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
    private Gun gun;
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
        gun = FindPlayerGun();
        shootingInterval = GetShootingInterval();
        inputManager = FindInputManager();
    }

    // Returns the current Gun from the Player. if no gun is equiped return a standart-Gun
    private Gun FindPlayerGun()
    {
        try
        {
            return GameObject.FindGameObjectWithTag("Player").GetComponent<Gun>();
        }
        catch (System.Exception)
        {
            logger.Log("No gun found",this);
            return new Gun();
        }
    }

    private float GetShootingInterval()
    {
        return 1.0f/gun.GetShootingSpeed();
    }

    private InputManager FindInputManager()
    {
        try
        {
            return GameObject.FindObjectOfType<InputManager>();
        }
        catch (System.Exception)
        {
            logger.Log("No gun found",this);
            return new InputManager();
        }
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
