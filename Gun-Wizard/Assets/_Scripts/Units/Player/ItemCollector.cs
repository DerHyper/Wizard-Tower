using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    Coin coin;
    [SerializeField] private TextMeshProUGUI coinText;
    private int coins = 0;

    void Start() {
        coin = GameObject.Find("MoneyManager").GetComponent<Coin>();
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Coin"))
        {
            Destroy(collider.gameObject);
            coins += coin.getValue();
            coinText.text = "Coins: " + coins;
        }
    }

    public int getCoins()
    {
        return coins;
    }
    
}
