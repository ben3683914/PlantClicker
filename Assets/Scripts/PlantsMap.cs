using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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
        if (tile.IsPlantable)
        {
            go = Instantiate(GameManager.Instance.TilesManager.GetTile(tileType), grid.GetPlaceableCellWorldPosition(coords), Quaternion.identity);
            Plants[coords] = go.gameObject;
        }

        return go.GetComponent<Tile>();
    }

    public void RemoveTile(Vector2 coords)
    {
        Destroy(Plants[coords]);
        Plants[coords] = null;
    }
}
