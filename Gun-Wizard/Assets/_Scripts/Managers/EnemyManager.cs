using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    [SerializeField]
    private int enemies = 0;

    private void Awake() {
        Instance = this;
    }

    public void IncreaseEnemyCount()
    {
        enemies++;
    }

    public void DecreaseEnemyCount()
    {
        enemies--;
        if (enemies <= 0)
        {
            ExitDoor.Instance.openDoor();
        }
    }


}
