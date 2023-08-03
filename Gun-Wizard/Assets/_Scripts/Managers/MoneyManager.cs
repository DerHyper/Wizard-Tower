using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    [SerializeField]
    private int coins;
    
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
        UpdateText();
    }
    void Start()
    {
        coins = 0;
    }

    public int getCoins()
    {
        return coins;
    }

    public void subtractCoins(int amount)
    {
        if (coins - amount < 0)
        {
            return;
        }
        coins -= amount;
        UpdateText();
    }

    public void addCoins(int amount)
    {
        coins += amount;
        UpdateText();
    }

    public void UpdateText()
    {
        TextMeshProUGUI coinText = Finder.FindCoinLable();
        coinText.text = coins.ToString();
    }
}
