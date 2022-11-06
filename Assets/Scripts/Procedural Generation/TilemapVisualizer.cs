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
    private TileBase floorTile, wallTop, wallSideRight, wallSideLeft, wallBottom,
        wallInnerCornerDownLeft, wallInnerCornerDownRight,
        wallDiagonalCornerDownRight, wallDiagonalCornerDownLeft, wallDiagonalCornerUpRight, wallDiagonalCornerUpLeft,
        L1, L2,
        U1, U2, U3, U4, II, II2, WallAll,
        Mixed1, Mixed2, Mixed3, Mixed4, Mixed5, Mixed6, Mixed7, Mixed8;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, floorTilemap, floorTile);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        /*foreach (var position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }*/
    }

    internal void PaintSingleBasicWall(Vector2Int position, string binaryType)
    {
        int typeAsInt = Convert.ToInt32(binaryType, 2);
        TileBase tile = null;
        if (WallHelper.wallTop.Contains(typeAsInt))
        {
            tile = wallTop;
        } else if (WallHelper.wallSideRight.Contains(typeAsInt))
        {
            tile = wallSideRight;
        }else if (WallHelper.wallSideLeft.Contains(typeAsInt))
        {
            tile = wallSideLeft;
        }else if (WallHelper.wallBottm.Contains(typeAsInt))
        {
            tile = wallBottom;
        }
        if (tile!=null)
            PaintSingleTile(floorTilemap, tile, position);
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear()
    {
        floorTilemap.ClearAllTiles();
    }

    internal void PaintSingleCornerWall(Vector2Int position, string binaryType)
    {
        int typeASInt = Convert.ToInt32(binaryType, 2);
        TileBase tile = null;

        if (WallHelper.wallInnerCornerDownLeft.Contains(typeASInt))
        {
            tile = wallInnerCornerDownLeft;
        }
        else if (WallHelper.wallInnerCornerDownRight.Contains(typeASInt))
        {
            tile = wallInnerCornerDownRight;
        }
        else if (WallHelper.wallDiagonalCornerDownLeft.Contains(typeASInt))
        {
            tile = wallDiagonalCornerDownLeft;
        }
        else if (WallHelper.wallDiagonalCornerDownRight.Contains(typeASInt))
        {
            tile = wallDiagonalCornerDownRight;
        }
        else if (WallHelper.wallDiagonalCornerUpRight.Contains(typeASInt))
        {
            tile = wallDiagonalCornerUpRight;
        }
        else if (WallHelper.wallDiagonalCornerUpLeft.Contains(typeASInt))
        {
            tile = wallDiagonalCornerUpLeft;
        }
        else if (WallHelper.wallBottmEightDirections.Contains(typeASInt))
        {
            tile = wallBottom;
        }
        else if (WallHelper.L1.Contains(typeASInt))
        {
            tile = L1;
        }
        else if (WallHelper.L2.Contains(typeASInt))
        {
            tile = L2;
        }
        else if (WallHelper.U1.Contains(typeASInt))
        {
            tile = U1;
        }
        else if (WallHelper.U2.Contains(typeASInt))
        {
            tile = U2;
        }
        else if (WallHelper.U3.Contains(typeASInt))
        {
            tile = U3;
        }
        else if (WallHelper.U4.Contains(typeASInt))
        {
            tile = U4;
        }
        else if (WallHelper.II.Contains(typeASInt))
        {
            tile = II;
        }
        else if (WallHelper.II2.Contains(typeASInt))
        {
            tile = II2;
        }
        else if (WallHelper.WallAll.Contains(typeASInt))
        {
            tile = WallAll;
        }

        else if (WallHelper.Mixed1.Contains(typeASInt))
        {
            tile = Mixed1;
        }

        else if (WallHelper.Mixed2.Contains(typeASInt))
        {
            tile = Mixed2;
        }

        else if (WallHelper.Mixed3.Contains(typeASInt))
        {
            tile = Mixed3;
        }

        else if (WallHelper.Mixed4.Contains(typeASInt))
        {
            tile = Mixed4;
        }

        else if (WallHelper.Mixed5.Contains(typeASInt))
        {
            tile = Mixed5;
        }

        else if (WallHelper.Mixed6.Contains(typeASInt))
        {
            tile = Mixed6;
        }

        else if (WallHelper.Mixed7.Contains(typeASInt))
        {
            tile = Mixed7;
        }

        else if (WallHelper.Mixed8.Contains(typeASInt))
        {
            tile = Mixed8;
        }

        if (tile != null)
            PaintSingleTile(floorTilemap, tile, position);
    }
}
