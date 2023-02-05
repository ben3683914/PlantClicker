using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Camera camera;

    private bool IsPlayActionsEnabled = true;

    private void Start()
    {
        GameManager.Instance.UIManager.OnDisablePlayActions.AddListener(DisablePlayActions);
        GameManager.Instance.UIManager.OnEnablePlayActions.AddListener(EnablePlayActions);
    }

    public void ButtonClick(InputAction.CallbackContext context)
    {
        if (IsPlayActionsEnabled)
        {
            if (context.performed)
            {
                GameManager.Instance.ClickerManager.PlacePLant(GetMouseWorldPosition());              
            }
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        var mousePos = Input.mousePosition;
        var worldPosition = camera.ScreenToWorldPoint(mousePos);

        return worldPosition;
    }

    void DisablePlayActions()
    {
        IsPlayActionsEnabled = false;
    }

    void EnablePlayActions()
    {
        IsPlayActionsEnabled = true;
    } 
}
