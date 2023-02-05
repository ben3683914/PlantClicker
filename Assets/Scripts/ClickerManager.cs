using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClickerManager : MonoBehaviour
{

    public int clickLevel;
    public Plant selectedPlant;

    // Start is called before the first frame update
    void Start()
    {
        selectedPlant = GameManager.Instance.PlantManager.GetPlantType(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlacePLant(Vector3 worldPos)
    {
        var gridmanager = GameManager.Instance.GridManager;
        var placedPlant = gridmanager.GetPlantFromWorldPosition(worldPos);
        if(placedPlant == null)
        {
            var plantedTileData = gridmanager.PlaceTileAtWorldPosition(selectedPlant, worldPos, clickLevel);
            int seeds = plantedTileData.Length * selectedPlant.level * selectedPlant.level;

            GameManager.Instance.SeedManager.AddSeeds(seeds);
        }
    }
}
