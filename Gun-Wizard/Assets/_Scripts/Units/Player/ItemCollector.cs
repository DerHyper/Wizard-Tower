using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other = collider.gameObject;

        if (other.CompareTag("Coin"))
        {
            if (other.GetComponent<MoneyDisplay>() != null)
            {
                MoneyManager.Instance.addCoins(other.GetComponent<MoneyDisplay>().GetValue());
            }
            Destroy(other); 
        }
    }
    
}
