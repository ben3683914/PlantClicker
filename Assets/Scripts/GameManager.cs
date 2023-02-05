using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GridManager GridManager;
    public InputManager InputManager;
    public ClickerManager ClickerManager;
    public PlantManager PlantManager;
    public SeedManager SeedManager;
    public UIManager UIManager;

    private void Awake()
    {
        Instance = this;
    }
}
