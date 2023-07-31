using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    [SerializeField]
    GameObject money;
    //drop amount of money at given position
    public void DropMoney(int amount, Vector2 position, Quaternion rotation){
        Vector2 dropPosition = CalculateRadius(position);
        int dropAmount = randomizeAmount(amount);

        GameObject coin = Instantiate(
            money, 
            dropPosition,
            rotation
        );
        Debug.Log("Dropped " + dropAmount + " coins on position " + dropPosition);
    }

    private Vector2 CalculateRadius(Vector2 position){
        float radius = Random.Range(1f,2f);
        Vector2 randomizedVector = new Vector2(position.x+radius, position.y+radius);
        return randomizedVector;
    }

    private int randomizeAmount(int amount){
        float random = Random.Range(0f,10f);
        int newAmount = (int)(amount + amount * (random/10));
        return newAmount;
    }
}
