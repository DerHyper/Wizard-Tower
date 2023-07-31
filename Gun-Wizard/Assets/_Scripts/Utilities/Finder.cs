using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Finder
{
    // Returns the current Logger or creates a new one.
    public static Logger FindLogger()
    {
        Logger logger = GameObject.FindObjectOfType<Logger>();;
        if (logger == null)
        {
            GameObject go = Object.Instantiate(new GameObject());
            return go.AddComponent<Logger>();
        }
        return logger;
    }

    // Returns the current Gun from the Player. if no gun is equiped return a standart-Gun
    public static WeaponDisplay FindPlayerGun()
    {
        GameObject player = FindPlayer();
        WeaponDisplay weaponDisplay = player.GetComponentInChildren<WeaponDisplay>();
        if (weaponDisplay == null)
        {
            Debug.Log("Could not find GunDisplay");
            throw new MissingComponentException(); 
        }
        return weaponDisplay;
    }

    // Returns the current Inputmanager or creates a new one.
    public static InputManager FindInputManager()
    {
        InputManager inputManager = GameObject.FindObjectOfType<InputManager>();;
        if (inputManager == null)
        {
            GameObject go = Object.Instantiate(new GameObject());
            return go.AddComponent<InputManager>();
        }
        return inputManager;
    }

    public static GameObject FindPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.Log("Could not find Player");
            throw new MissingComponentException();
        }
        return player;
    }

    public static DropManager FindDropManager()
    {
        DropManager dropManager = GameObject.FindObjectOfType<DropManager>();;
        if (dropManager == null)
        {
            GameObject go = Object.Instantiate(new GameObject());
            return go.AddComponent<DropManager>();
        }
        return dropManager;
    }
}
