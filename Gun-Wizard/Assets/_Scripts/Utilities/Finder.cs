using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Finder
{
    // Returns the current Logger or creates a new one.
    public static Logger FindLogger()
    {
        Logger logger = GameObject.FindObjectOfType<Logger>();;
        if (logger != null)
        {
            return logger;
        }
        GameObject go = Object.Instantiate(new GameObject());
        return go.AddComponent<Logger>();
    }

    // Returns the current Gun from the Player. if no gun is equiped return a standart-Gun
    public static RangedWeaponDisplay FindPlayerGun()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            RangedWeaponDisplay rangedWeaponDisplay = player.GetComponentInChildren<RangedWeaponDisplay>();
            if (rangedWeaponDisplay != null)
            {
                return rangedWeaponDisplay;
            }
            Debug.Log("Could not find GunDisplay");
            throw new MissingComponentException();
        }
        Debug.Log("Could not find Player");
        throw new MissingComponentException();
    }

    // Returns the current Inputmanager or creates a new one.
    public static InputManager FindInputManager()
    {
        InputManager inputManager = GameObject.FindObjectOfType<InputManager>();;
        if (inputManager != null)
        {
            return inputManager;
        }
        GameObject go = Object.Instantiate(new GameObject());
        return go.AddComponent<InputManager>();
    }
}
