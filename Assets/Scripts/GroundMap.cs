using UnityEngine;

public class GroundMap : MonoBehaviour
{
    private Grid grid;

    public GroundMap(Grid grid)
    {
        this.grid = grid;

        for(int x = 0; x < grid.GetWidth(); x++){
            for(int y = 0; y < grid.GetHeight(); y++)
            {
                Instantiate(GameManager.Instance.TilesManager.GetTile(TilesManager.TileType.Grass), grid.GetPlaceableCellWorldPosition(x, y), Quaternion.identity);
            }
        }
    }
}
