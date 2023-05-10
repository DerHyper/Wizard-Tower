using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomWalk", menuName = "ScriptableObject/RandomWalk")]
public class RandomWalk : ScriptableObject
{
    public int iterations = 10;
    public int walkLength = 10;
    public bool startRandomly = true;
}
