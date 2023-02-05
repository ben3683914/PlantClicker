using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public MapManager MapManager;
    //public GridManager GridManager;
    public InputManager InputManager;
    //public PlantManager PlantManager;
    public SeedManager SeedManager;
    public UIManager UIManager;
    public TilesManager TilesManager;
    public ClickerManager ClickerManager;

    private void Awake()
    {
        Instance = this;
    }
}
