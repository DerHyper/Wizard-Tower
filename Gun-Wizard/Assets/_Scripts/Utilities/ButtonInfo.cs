using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInfo : MonoBehaviour
{
    [SerializeField]
    public int ItemID;

    [SerializeField]
    public TextMeshProUGUI PriceText;

    [SerializeField]
    public TextMeshProUGUI QuantityText;

    [SerializeField]
    public GameObject ShopManager;

    

    // Update is called once per frame
    void Update()
    {
        PriceText.text = " $" + ShopManager.GetComponent<ShopManagerScript>().shopItems[2, ItemID].ToString();
        QuantityText.text = "Level: " + ShopManager.GetComponent<ShopManagerScript>().shopItems[3, ItemID].ToString();
    }
}
