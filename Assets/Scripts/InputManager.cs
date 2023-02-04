using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Manager
{
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameManager.GridManager.GetGridCellAtWorldPosition(GetMouseWorldPosition()));
    }

    public void ButtonClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var worldPos = GetMouseWorldPosition();
            var gridManager = GameObject.Find("GridManager").GetComponent<GridManager>();

            
            var plant = gridManager.GetPlantFromWorldPosition(worldPos);
            if(plant != null)
                Debug.Log($"the name: {plant.name}");
            

            gridManager.PlaceTileAtWorldPosition(Tiles.Type.PotatoPlant, worldPos);
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        var mousePos = Input.mousePosition;
        var worldPosition = camera.ScreenToWorldPoint(mousePos);

        return worldPosition;
    }


}
