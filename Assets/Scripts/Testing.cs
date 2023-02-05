using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    private GridSystem grid;
    void Start()
    {
        grid = new GridSystem(15, 10, 10f, new Vector3(0,0));

        var gameMap = new GameMap(grid);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 56);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }

    private class GameMap
    {
        private GridSystem grid;

        public GameMap(GridSystem grid)
        {
            this.grid = grid;

            for(int x = 0; x < grid.GetWidth(); x++){
                for(int y = 0; y < grid.GetHeight(); y++)
                {
                    // instantiate a tile
                }
            }
        }
    }
}
