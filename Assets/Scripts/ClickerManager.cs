using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerManager : MonoBehaviour
{

    public int clickLevel;
    public Plant plant;

    // Start is called before the first frame update
    void Start()
    {
        plant = GameManager.Instance.PlantManager.GetPlantType(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
