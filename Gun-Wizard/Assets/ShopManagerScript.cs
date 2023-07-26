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

    ItemCollector itemCollector;
   
    void Start()
    {
        itemCollector = GameObject.Find("GameManager").GetComponent<ItemCollector>();

        initArray(new int[3,3]{{1,2,3},{50,100,150},{0,0,0}});
        
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

        if (itemCollector.getCoins() >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            itemCollector.substractCoins(shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]); //ausgegebenen Betrag abziehen
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++; //Anzahl Items im Inventar erhöhen
            itemCollector.UpdateText(); //Anzhal Coins Text updaten
            ButtonRef.GetComponent<ButtonInfo>().QuantityText.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString(); //Anzahl gekaufte Items updaten

        }
    }
}
