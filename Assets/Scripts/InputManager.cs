using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameManager.Instance.GridManager.GetGridCellAtWorldPosition(GetMouseWorldPosition()));
    }

    public void ButtonClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var worldPos = GetMouseWorldPosition();

            
            var plant = GameManager.Instance.GridManager.GetPlantFromWorldPosition(worldPos);
            if(plant != null)
                Debug.Log($"the name: {plant.name}");


            GameManager.Instance.GridManager.PlaceTileAtWorldPosition(Tiles.Type.PotatoPlant, worldPos);
            GameManager.Instance.SeedManager.AddSeeds();
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        var mousePos = Input.mousePosition;
        var worldPosition = camera.ScreenToWorldPoint(mousePos);

        return worldPosition;
    }


}
