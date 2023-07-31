using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] money;
    int dropAmount;
    //drop amount of money at given position
    public void DropMoney(int amount, Vector2 position, Quaternion rotation){
        Vector2 dropPosition;
        dropAmount = randomizeAmount(amount);
        Debug.Log("Will drop " + dropAmount);

        while (dropAmount > 0){
            int index = calculateCoin(dropAmount);
            dropPosition = CalculateRadius(position);

            GameObject coin = Instantiate(
            money[index], 
            dropPosition,
            rotation
            );

        Debug.Log("Dropped " + dropAmount + " coins on position " + dropPosition);
        }
    }

    private Vector2 CalculateRadius(Vector2 position){
        Vector2 randomVector = new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f));
        return position + randomVector;
    }

    private int randomizeAmount(int amount){
        float random = Random.Range(0f,10f);
        int newAmount = (int)(amount + amount * (random/10));
        return newAmount;
    }

    private int calculateCoin(int amountOfMoney){
        if (amountOfMoney >= 10){
            dropAmount -= 10;
            return 0;
        } 
        else if (amountOfMoney >= 5){
            dropAmount -= 5;
            return 1;
        }
        else{
            dropAmount -= 1;
            return 2;
        }
    }
}
