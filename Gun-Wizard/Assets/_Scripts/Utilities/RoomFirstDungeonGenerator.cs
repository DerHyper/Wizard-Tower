using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFirstDungeonGenerator : RandomWalkGenerator
{
    [SerializeField]
    private int minRoomWidth = 4;

    [SerializeField]
    private int minRoomHeight = 4;

    [SerializeField]
    private int dungeonWidth = 20;
    
    [SerializeField]
    private int dungeonHeight = 20;

    //prevent that rooms are to close to each other
    [SerializeField]
    [Range(0, 10)]
    private int offset = 1;

    //use the random walk algorithm or create rooms from box
    [SerializeField]
    private bool randomWalkRooms = false;

    protected override void RunProceduralGeneration()
    {
        CreateRooms();
    }

    private void CreateRooms()
    {
        var roomsList = ProceduralGenerationAlgorithms.BinarySpacePartitioning(new BoundsInt((Vector3Int)startPosition,
            new Vector3Int(dungeonWidth, dungeonHeight, 0)), minRoomWidth, minRoomHeight);

        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        floor = CreateSimpleRooms(roomsList);

        tilemapVisualizer.PaintFloorTiles(floor);
        WallGenerator.CreateWalls(floor, tilemapVisualizer);
    }

    private HashSet<Vector2Int> CreateSimpleRooms(List<BoundsInt> roomsList)
    {
        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        foreach (var room in roomsList)
        {
            for (int col = offset; col < room.size.x - offset; col++)
            {
                for (int row = offset; row < room.size.y - offset; row++)
                {
                    Vector2Int position = (Vector2Int)room.min + new Vector2Int(col, row);
                    floor.Add(position);
                }
            }
        }
        return floor;
    }
}
