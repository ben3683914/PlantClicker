using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClickerManager : MonoBehaviour
{

    public int clickLevel = 1;
    public TilesManager.TileType selectedPlant;

    //// Start is called before the first frame update
    void Start()
    {
        selectedPlant = TilesManager.TileType.Potatoe;
    }

    public void PlacePLant(Vector3 worldPos)
    {
        var grid = GameManager.Instance.MapManager.grid;
        var plantsMap = GameManager.Instance.MapManager.PlantsMap;
        var cell = grid.GetCellAtWorldPosition(worldPos);
        var plant = plantsMap.GetPlantAtGridCell(cell);

        if(plant == null)
        {
            var tile = plantsMap.SetTile(selectedPlant, cell);
            int seeds = 1;
            GameManager.Instance.SeedManager.AddSeeds(seeds);
        }

        //var gridmanager = GameManager.Instance.GridManager;
        //var placedPlant = gridmanager.GetPlantFromWorldPosition(worldPos);
        //if (placedPlant == null)
        //{
        //    var plantedTileData = gridmanager.PlaceTileAtWorldPosition(selectedPlant, worldPos, clickLevel);
        //    int seeds = plantedTileData.Length * selectedPlant.level * selectedPlant.level;

        //    GameManager.Instance.SeedManager.AddSeeds(seeds);
        //}
    }
}
