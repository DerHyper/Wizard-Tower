using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    static void Spawn(GameObject item, Vector2 position)
    {
        Instantiate(item, position, Quaternion.identity);
    }
}
