using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomWalkAlgorithm
{
    //Hashset, because we only want to step once on each field
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPos, int walkLength)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();
        path.Add(startPos);
        var previousPos = startPos;

        for (int i = 0; i < walkLength; i++)
        {
            var newPosition = previousPos + Direction2D.GetRandomCardinalDirection();
            path.Add(newPosition);
            previousPos = newPosition;
        }

        return path;
    }

    //List beacuse we want to know, which was the last position we visited
    public static List<Vector2Int> RandomWalkCorridor(Vector2Int startPosition, int corridorLength)
    {
        List<Vector2Int> corridor = new List<Vector2Int>();
        var direction = Direction2D.GetRandomCardinalDirection();
        var currentPos = startPosition;
        corridor.Add(currentPos); //start position
        for (int i = 0; i < corridorLength; i++)
        {
            currentPos += direction;
            corridor.Add(currentPos);
        }
        return corridor;
    }
   
}


public static class Direction2D
{
    public static List<Vector2Int> cardinalDirectionList = new List<Vector2Int>
    {
        new Vector2Int(0,1), //UP
        new Vector2Int(1,0), //RIGHT
        new Vector2Int(0,-1), //DOWN
        new Vector2Int(-1,0), //LEFT
    };

    public static Vector2Int GetRandomCardinalDirection()
    {
        return cardinalDirectionList[Random.Range(0, cardinalDirectionList.Count)];
    }
}
