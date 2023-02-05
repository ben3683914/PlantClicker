using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public UnityEvent OnDisablePlayActions;
    public UnityEvent OnEnablePlayActions;

    private void Start()
    {
        if (OnDisablePlayActions == null)
            OnDisablePlayActions = new UnityEvent();

        if (OnEnablePlayActions == null)
            OnEnablePlayActions = new UnityEvent();
    }
}
