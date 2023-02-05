using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GroundMap GroundMap;
    public PlantsMap PlantsMap;

    public Grid grid;

    void Awake()
    {
        grid = new Grid(500, 500, 10f, new Vector3(0, 0));

        GroundMap = new GroundMap(grid);
        PlantsMap = new PlantsMap(grid);
    }
}
