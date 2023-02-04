using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public Tilemap plantsTilemap;
    public List<Tile> baseTiles;
    public Dictionary<Tiles.Type, MapTile> mapTiles;
    private GridLayout gridLayout;

    // Start is called before the first frame update
    void Start()
    {
        mapTiles = new Dictionary<Tiles.Type, MapTile>();
        gridLayout = GetComponent<GridLayout>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetupMapTiles()
    {
        // Grass
        mapTiles.Add(
            Tiles.Type.Grass,
            new MapTile()
            {
                Name = "Grass",
                Tile = baseTiles[0]
            }
        );

        // Potato Plant
        mapTiles.Add(
            Tiles.Type.PotatoPlant,
            new MapTile()
            {
                Name = "Potato",
                Tile = baseTiles[1]
            }
        );
    }
}
