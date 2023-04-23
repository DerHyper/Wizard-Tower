using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    Transform firePoint;

    [SerializeField]
    Logger logger;
    
    [SerializeField]
    GameObject bullet;

    public InputAction inputAction;
    private Gun gun;
    private float shootingInterval;
    private float timeSinceLastShoot;

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable() {
        inputAction.Disable();
    }

    void FixedUpdate()
    {
        if (GetIsShooting() && GetCanShootAgain())
        {
            ShootBullet();
        }
    }

    void Start()
    {
        shootingInterval = GetShootingInterval();
    }

    // Returns 
    private float GetShootingInterval()
    {
        try
        {
            gun = GameObject.FindGameObjectWithTag("Player").GetComponent<Gun>();
            return 1.0f/gun.GetShootingSpeed();
        }
        catch (System.Exception)
        {
            logger.Log("No gun found",this);
            return shootingInterval = 0.1f;
        }
    }

    // Retruns 'true' is the player is pressing a shoot-button (e.g. Arrow Keys or the right Joystick of a Gamepad)
    private bool GetIsShooting()
    {
        Vector2 shootDirection = inputAction.ReadValue<Vector2>();
        return shootDirection.magnitude > 0;
    }

    // Transforms Input-Vektor to a Quaternion
    private Quaternion GetShootQuaternion()
    {
        Vector2 shootDirection = inputAction.ReadValue<Vector2>();
        Quaternion OriginalQuaternion = Quaternion.LookRotation(Vector3.forward, shootDirection);
        Quaternion TransformedQuaternion = OriginalQuaternion * Quaternion.Euler(0, 0, 90);
        return TransformedQuaternion;
    } 

    // Spawns a Bullet with the attributes of the Gun equipped.
    private void ShootBullet()
    {
        logger.Log("FIRE!",this);

        Instantiate(
            bullet, 
            gameObject.transform.position, 
            GetShootQuaternion()
        );
    }
    
    // returns true if Player can shoot again
    private bool GetCanShootAgain()
    {
        timeSinceLastShoot += Time.deltaTime;
        if (timeSinceLastShoot > shootingInterval)
        {
            timeSinceLastShoot = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}
