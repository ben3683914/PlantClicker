using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static TilesManager;

public class PlantsMap : MonoBehaviour
{
    private Grid grid;
    private Dictionary<Vector2, GameObject> Plants;

    public PlantsMap(Grid grid)
    {
        this.grid = grid;
        Plants = new Dictionary<Vector2, GameObject>();

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                var coords = new Vector2Int(x, y);
                //var go = SetTile(TilesManager.TileType.Potatoe, coords);
                //Plants.Add(coords, go.gameObject);
                Plants.Add(coords, null);
            }
        }
    }

    public Tile GetPlantAtGridCell(Vector2Int coords)
    {
        var plant = Plants[coords];

        if (plant == null)
            return null;

        return plant.GetComponent<Tile>();
    }

    public Tile SetTile(TilesManager.TileType tileType, Vector2Int coords)
    {
        GameObject go = null;

        var tile = (GameManager.Instance.TilesManager.GetTile(tileType).GetComponent<Tile>());
        var plant = GetPlantAtGridCell(coords);
        var seeds = GameManager.Instance.SeedManager.GetSeeds();
        var seedCost = 1 * (int) tileType;
        if (tile.IsPlantable && plant == null && seeds >= seedCost)
        {
            go = Instantiate(GameManager.Instance.TilesManager.GetTile(tileType), grid.GetPlaceableCellWorldPosition(coords), Quaternion.identity);
            Plants[coords] = go.gameObject;
            GameManager.Instance.SeedManager.AddSeeds(seedCost * -1);
        }

        return go?.GetComponent<Tile>();
    }

    public List<Tile> SetTiles(TilesManager.TileType tileType, Vector2Int coords, int size)
    {
        var cells = grid.GetSquareRangeOfCells(coords, size);
        var tiles = new List<Tile>();

        foreach (var cell in cells)
        {
            var tile = SetTile(tileType, cell);
            if(tile != null)
            {
                tiles.Add(tile);
            }
        }

        return tiles;
    }

    public void SetTile(int size)
    {
        // for size
        //  get coords where mouse
        //  coords[0] + new vector3(size)
        //  setTile()
    }

    public void RemoveTile(Vector2 coords)
    {
        GameObject go = Plants.ContainsKey(coords) ? Plants[coords] : null;
        if (go != null)
        {
            var tile = go.GetComponent<Tile>();
            if (tile.IsHarvestable)
            {
                var seedYeild = 3 * (int)tile.Type;
                Destroy(go);
                Plants[coords] = null;
                GameManager.Instance.SeedManager.AddSeeds(seedYeild);
            }
        }
    }

    public void RemoveTiles(Vector2Int coords, int size)
    {
        var cells = grid.GetSquareRangeOfCells(coords, size);

        foreach (var cell in cells)
        {
            RemoveTile(new Vector2(coords.x, coords.y));
        }
    }
}
