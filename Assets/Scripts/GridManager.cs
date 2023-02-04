using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public Tilemap plantsTilemap;
    public List<Tile> baseTiles;
    public Grid grid;
    // Start is called before the first frame update
    void Start()
    {
    }

    public Vector3Int GetGridCellAtWorldPosition(Vector3 worldPosition)
    {
        var cellPos = grid.WorldToCell(worldPosition);
        return cellPos;
    }

    public Plant GetPlantFromCell(Vector3Int cellCoords)
    {
        var tile = plantsTilemap.GetTile(cellCoords) as Tile;

        if (tile == null)
            return null;

        return GameManager.Instance.PlantManager.plantTypes.FirstOrDefault(plant => plant.Tile);
    }

    public Plant GetPlantFromWorldPosition(Vector3 worldPosition)
    {
        var gridCell = GetGridCellAtWorldPosition(worldPosition);
        var tile = GetPlantFromCell(gridCell);
        return tile;
    }

    public void PlaceTileAtCell(Tiles.Type type, Vector3Int cellCoords)
    {
        plantsTilemap.SetTile(cellCoords, GameManager.Instance.PlantManager.GetPlantType(type).Tile);
    }

    public void PlaceTileAtWorldPosition(Tiles.Type type, Vector3 worldPosition)
    {
        var gridCell = GetGridCellAtWorldPosition(worldPosition);
        PlaceTileAtCell(type, gridCell);
    }
}
