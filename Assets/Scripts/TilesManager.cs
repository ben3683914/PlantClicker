using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    public TileObject[] Tiles;

    [Serializable]
    public struct TileObject
    {
        public TileType Type;
        public GameObject Tile;
    }

    public enum TileType
    {
        Grass,
        Potatoe
    }
    
    public GameObject GetTile(TileType type)
    {
        foreach(var t in Tiles)
        {
            if (t.Type == type)
                return t.Tile;
        }

        throw new Exception("Undefined type");
    }
}
