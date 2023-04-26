using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    Coin coinScript;
    public GameObject coin;
    void Start() 
    {
        coinScript = GameObject.Find("MoneyManager").GetComponent<Coin>();
        coinScript.setValue(10);
        Instantiate(coin, new Vector3(244, 152, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
