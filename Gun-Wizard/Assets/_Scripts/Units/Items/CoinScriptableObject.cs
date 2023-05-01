using UnityEngine;

[CreateAssetMenu(fileName = "CoinScriptableObject", menuName = "ScriptableObject/Coin")]
public class CoinScriptableObject : ScriptableObject
{
    [field: SerializeField]
    public int value {get; private set;} = 5;
}
