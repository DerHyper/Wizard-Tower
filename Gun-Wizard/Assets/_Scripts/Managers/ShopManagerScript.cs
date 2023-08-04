using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManagerScript : MonoBehaviour
{
    [SerializeField]
    public int[,] shopItems = new int[4,4];

    GameObject player;
   
    void Start()
    {
        initArray(new int[3,3]{{1,2,3},{999,10,20},{0,0,0}});
        player = Finder.FindPlayer();
    }

    private void initArray(int[,] values)
    {
        for (int i = 0; i < values.GetLength(0); i++)
        {
            for (int j = 0; j < values.GetLength(1); j++)
            {
                shopItems[i+1,j+1] = values[i,j];
            }
        }
    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
 
        if (MoneyManager.Instance.getCoins() >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            MoneyManager.Instance.subtractCoins(shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]); //ausgegebenen Betrag abziehen
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++; //Anzahl Items im Inventar erhöhen
            MoneyManager.Instance.UpdateText(); //Anzahl Coins Text updaten
            ButtonRef.GetComponent<ButtonInfo>().QuantityText.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString(); //Anzahl gekaufte Items updaten
            if(ButtonRef.GetComponent<ButtonInfo>().ItemID == 1)
            {
                Debug.Log("");
                return;
            }
            else if(ButtonRef.GetComponent<ButtonInfo>().ItemID == 2)
            {
                PlayerStats.Instance.SetDamageMultiplicator(0.1f);
                return;
            }
            else if(ButtonRef.GetComponent<ButtonInfo>().ItemID == 3)
            {
                PlayerStats.Instance.SetAttackSpeedMultiplicator(1f);
                return;
            }
            //player.GetComponent<PlayerHealth>().IncreaseHealth(0.5f);
        }
    }
}
