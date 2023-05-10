using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq; //Library to query any Collection
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomWalkGenerator : AbstractDungeonGenerater
{
    //maximum possible iterations
    //in average it will be less, because it does not save fields that were visited twice
    [SerializeField]
    private RandomWalk randomWalkParameters;

    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPos = RunRandomWalk();
        tilemapVisualizer.Clear();
        tilemapVisualizer.PaintFloorTiles(floorPos);
    }

    protected HashSet<Vector2Int> RunRandomWalk()
    {
        var currentPos = startPosition;
        HashSet<Vector2Int> floorPos = new HashSet<Vector2Int>();
        for (int i = 0; i < randomWalkParameters.iterations; i++)
        {
            var path = RandomWalkAlgorithm.SimpleRandomWalk(currentPos, randomWalkParameters.walkLength);
            floorPos.UnionWith(path); //union both, without duplicates
            if (randomWalkParameters.startRandomly)
            {
                currentPos = floorPos.ElementAt(Random.Range(0, floorPos.Count));
            }
        }
        return floorPos;
    }
}
