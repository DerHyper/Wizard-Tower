using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap;

    [SerializeField]
    private Tilemap wallTilemap;

    [SerializeField]
    private TileBase floorTile, wallTop, wallSideRight, wallSideLeft, wallBottom, wallFull,
        wallInnerCornerDownLeft, wallInnerCornerDownRight, wallInnerCornerUpLeft, wallInnerCornerUpRight,
        wallDiagonalCornerDownLeft, wallDiagonalCornerDownRight, wallDiagonalCornerUpLeft, wallDiagonalCornerUpRight,
        wallOpenDown, wallOpenUp, wallOpenLeft, wallOpenRight, wallOpenLeftRight, wallOpenUpDown;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, floorTilemap, floorTile);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear()
    {
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
    }

    internal void PaintSingleBasicWall(Vector2Int position, string binaryType)
    {
        int typeAsInt = Convert.ToInt32(binaryType, 2); //string to int
        TileBase tile = null;
        if (WallTypesHelper.wallTop.Contains(typeAsInt))
        {
            tile = wallTop;
        }
        else if (WallTypesHelper.wallSideRight.Contains(typeAsInt))
        {
            tile = wallSideRight;
        }
        else if (WallTypesHelper.wallSideLeft.Contains(typeAsInt))
        {
            tile = wallSideLeft;
        }
        else if (WallTypesHelper.wallBottm.Contains(typeAsInt))
        {
            tile = wallBottom;
        }
        else if (WallTypesHelper.wallFull.Contains(typeAsInt))
        {
           tile = wallFull;
        }
        if ( tile != null)
        {
            PaintSingleTile(wallTilemap, tile, position);
        }
    }

    internal void PaintSingleCornerWall(Vector2Int position, string binaryType)
    {
        int typeAsInt = Convert.ToInt32(binaryType, 2); //string to int
        TileBase tile = null;
        //inner corners
        if (WallTypesHelper.wallInnerCornerDownLeft.Contains(typeAsInt))
        {
            tile = wallInnerCornerDownLeft;
        }
        else if (WallTypesHelper.wallInnerCornerDownRight.Contains(typeAsInt))
        {
            tile = wallInnerCornerDownRight;
        }
        else if (WallTypesHelper.wallInnerCornerUpRight.Contains(typeAsInt))
        {
            tile = wallInnerCornerUpRight;
        }
        else if (WallTypesHelper.wallInnerCornerUpLeft.Contains(typeAsInt))
        {
            tile = wallInnerCornerUpLeft;
        }
        //diagonal corners

        else if (WallTypesHelper.wallDiagonalCornerDownLeft.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerDownLeft;
        }
        else if (WallTypesHelper.wallDiagonalCornerDownRight.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerDownRight;
        }
        else if (WallTypesHelper.wallDiagonalCornerUpLeft.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerUpLeft;
        }
        else if (WallTypesHelper.wallDiagonalCornerUpRight.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerUpRight;
        }
        //else if (WallTypesHelper.wallFullEightDirections.Contains(typeAsInt))
        //{
        //  tile = wallFull;
        //}
        //else if (WallTypesHelper.wallBottmEightDirections.Contains(typeAsInt))
        //{
        //   tile = wallBottom;
        //}

        //three side walls
        else if (WallTypesHelper.wallOpenDown.Contains(typeAsInt))
        {
            tile = wallOpenDown;
        }

        else if (WallTypesHelper.wallOpenUp.Contains(typeAsInt))
        {
            tile = wallOpenUp;
        }

        else if (WallTypesHelper.wallOpenLeft.Contains(typeAsInt))
        {
            tile = wallOpenLeft;
        }

        else if (WallTypesHelper.wallOpenRight.Contains(typeAsInt))
        {
            tile = wallOpenRight;
        }

        else if (WallTypesHelper.wallOpenLeftRight.Contains(typeAsInt))
        {
            tile = wallOpenLeftRight;
        }

        else if (WallTypesHelper.wallOpenUpDown.Contains(typeAsInt))
        {
            tile = wallOpenUpDown;
        }

        if ( tile != null)
        {
            PaintSingleTile(wallTilemap, tile, position);
        }
        
    }

}
