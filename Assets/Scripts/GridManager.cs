using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    //public Vector3Int GetGridCellAtWorldPosition(Vector3 worldPosition)
    //{
    //    var cellPos = grid.WorldToCell(worldPosition);
    //    return cellPos;
    //}

    //public Plant GetPlantFromCell(Vector3Int cellCoords)
    //{
    //    var tile = plantsTilemap.GetTile(cellCoords) as Tile;

    //    if (tile == null)
    //        return null;

    //    return GameManager.Instance.PlantManager.GetPlantType(tile);
    //}

    //public Plant GetPlantFromWorldPosition(Vector3 worldPosition)
    //{
    //    var gridCell = GetGridCellAtWorldPosition(worldPosition);
    //    var tile = GetPlantFromCell(gridCell);
    //    return tile;
    //}

    //public void PlaceTilesAtCell(Tiles.Type type, TileChangeData[] tileChangeData)
    //{
    //    plantsTilemap.SetTiles(tileChangeData, false);
    //}

    //public TileChangeData[] PlaceTileAtWorldPosition(Plant plant, Vector3 worldPosition, int range)
    //{
    //    var startingCell = GetGridCellAtWorldPosition(worldPosition);
    //    var tile = plant.Tiles[0];
    //    TileChangeData[] tileChangeData = GetSquareRangeOfCells(startingCell, range)
    //        .Where(cell => GetPlantFromCell(cell) == null)
    //        .Select(cell => new TileChangeData(cell, tile, UnityEngine.Color.white, Matrix4x4.Scale(Vector3.one)))
    //        .ToArray();
    //    plantsTilemap.SetTiles(tileChangeData, false);
    //    return tileChangeData;
    //}

    //public IList<Vector3Int> GetSquareRangeOfCells(Vector3Int startPos, int range)
    //{
    //    Vector3Int cellRange = new Vector3Int(range, range, 0);
    //    Vector3Int[] cells = new Vector3Int[range * range];

    //    for (int i = 0; i < cells.Length; i++)
    //    {
    //        var cell = new Vector3Int(i % cellRange.x, i / cellRange.y, 0);
    //        cells[i] = cell + startPos;
    //    }
    //    return cells;
    //}

}
