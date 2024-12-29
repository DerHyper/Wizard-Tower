using UnityEngine;

[CreateAssetMenu(fileName = "Money", menuName = "ScriptableObject/Money")]
public class Money : ScriptableObject
{
    [field: SerializeField]
    public int value {get; private set;} = 5;

    [field: SerializeField]
    public Sprite visual;

}
