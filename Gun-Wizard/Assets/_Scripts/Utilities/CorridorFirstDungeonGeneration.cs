using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorFirstDungeonGeneration : RandomWalkGenerator
{
    [SerializeField]
    private int corridorLength = 14;

    [SerializeField]
    private int corridorCount = 5;

    [SerializeField]
    [Range(0.1f,1)]
    private float roomPercent = 0.8f;
    public RandomWalk roomGenerationParameters;

    protected override void RunProceduralGeneration()
    {
        CorridorFirstGeneration();
    }

    private void CorridorFirstGeneration()
    {
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();

        CreateCorridors(floorPositions);

        tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tilemapVisualizer);
    }

    private void CreateCorridors(HashSet<Vector2Int> floorPositions)
    {
        var currentPos = startPosition;

        for (int i = 0; i < corridorCount; i++)
        {
            var corridor = RandomWalkAlgorithm.RandomWalkCorridor(currentPos, corridorLength);
            currentPos = corridor[corridor.Count -1];
            floorPositions.UnionWith(corridor);
        }
    }
}
