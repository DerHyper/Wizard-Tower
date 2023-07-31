using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    [field: SerializeField]
    Money money;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = money.visual;
    }

    public int GetValue()
    {
        return money.value;
    }

}
