using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClickerManager : MonoBehaviour
{

    public int clickLevel = 1;
    public int levelUpgradeCostMultiplier = 10;
    public TilesManager.TileType selectedPlant;

    //// Start is called before the first frame update
    void Start()
    {
        selectedPlant = TilesManager.TileType.Potatoe;
    }

    public void ClickPlant(Vector3 worldPos)
    {
        var grid = GameManager.Instance.MapManager.grid;
        var plantsMap = GameManager.Instance.MapManager.PlantsMap;
        var cell = grid.GetCellAtWorldPosition(worldPos);
        var plant = plantsMap.GetPlantAtGridCell(cell);

        if (plant != null)
        {
            plantsMap.RemoveTiles(cell, clickLevel);
        }
        else
        {
            plantsMap.SetTiles(selectedPlant, cell, clickLevel);
        }
    }
}
