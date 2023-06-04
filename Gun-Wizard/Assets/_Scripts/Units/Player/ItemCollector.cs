using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    private int coins = 300;

    void Start() 
    {
        UpdateText();
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other = collider.gameObject;

        if (other.CompareTag("Coin"))
        {
            if (other.GetComponent<MoneyDisplay>() != null)
            {
                coins += other.GetComponent<MoneyDisplay>().GetValue();
                coinText.text = "Coins: " + coins;
            }
            Destroy(other); 
        }
    }

    public int getCoins()
    {
        return coins;
    }

    public void setCoins(int amount)
    {
        coins -= amount;
    }

    public void UpdateText()
    {
        coinText.text = "Coins: " + coins;
    }
    
}
