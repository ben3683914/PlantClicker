using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    Tile Tile;

    private void Start()
    {
        Tile = GetComponent<Tile>();
        Tile.Type = TilesManager.TileType.Grass;
    }
}
