using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public Tilemap plantsTilemap;
    public List<Tile> baseTiles;
    public Dictionary<Tile, TileData> mapTileTypes;
    public Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        mapTileTypes = new Dictionary<Tile, TileData>();
        SetupMapTileTypes();
    }

    void SetupMapTileTypes()
    {
        // Grass
        mapTileTypes.Add(
            baseTiles[0],
            new TileData()
            {
                Name = "Grass",
                Tile = baseTiles[0],
                Type = Tiles.Type.Grass
            }
        );

        // Potato Plant
        mapTileTypes.Add(
            baseTiles[1],
            new TileData()
            {
                Name = "Potato",
                Tile = baseTiles[1],
                Type = Tiles.Type.PotatoPlant
            }
        );
    }

    public Tile GetTileByType(Tiles.Type type)
    {
        foreach(var tile in mapTileTypes.Values)
        {
            if (tile.Type == type)
                return tile.Tile;
        }

        return null;
    }

    public Vector3Int GetGridCellAtWorldPosition(Vector3 worldPosition)
    {
        var cellPos = grid.WorldToCell(worldPosition);
        return cellPos;
    }

    public TileData GetTileFromCell(Vector3Int cellCoords)
    {
        var tile = plantsTilemap.GetTile(cellCoords) as Tile;

        if (tile == null)
            return null;

        return mapTileTypes[tile];
    }

    public TileData GetTileFromWorldPosition(Vector3 worldPosition)
    {
        var gridCell = GetGridCellAtWorldPosition(worldPosition);
        var tile = GetTileFromCell(gridCell);
        return tile;
    }

    public void PlaceTileAtCell(Tiles.Type type, Vector3Int cellCoords)
    {
        plantsTilemap.SetTile(cellCoords, GetTileByType(type));
    }

    public void PlaceTileAtWorldPosition(Tiles.Type type, Vector3 worldPosition)
    {
        var gridCell = GetGridCellAtWorldPosition(worldPosition);
        PlaceTileAtCell(type, gridCell);
    }
}
