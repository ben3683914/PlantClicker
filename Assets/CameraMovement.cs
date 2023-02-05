using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    private CameraControls cameraActions;
    private InputAction movement;
    private Transform cameraTransform;
    private Camera cam;

    [SerializeField]
    private float maxSpeed = 5f;
    private float speed;

    [SerializeField]
    private float acceleration = 10f;
    [SerializeField]
    private float damping = 15f;

    [SerializeField]
    private float stepSize = 2f;

    [SerializeField]
    private float zoomDampening = 7.5f;

    [SerializeField]
    private float minHeight = 5f;

    [SerializeField]
    private float maxHeight = 50f;

    [SerializeField]
    private float zoomSpeed = 2f;

    [SerializeField]
    private float edgeTolerance = 0.05f;

    private Vector3 targetPosition;

    private float zoomHeight;

    private Vector3 horizontalVelocity;
    private Vector3 lastPosition;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        cameraActions = new CameraControls();
        cameraTransform = cam.transform;
    }

    private void OnEnable()
    {
        cameraTransform.LookAt(this.transform);
        lastPosition = this.transform.position;
        movement = cameraActions.Camera.MoveCamera;
        cameraActions.Camera.Enable();

        cameraActions.Camera.ZoomCamera.performed += ZoomCamera;
        zoomHeight = cam.orthographicSize;
    }

    private void OnDisable()
    {
        cameraActions.Camera.Disable();
        cameraActions.Camera.ZoomCamera.performed -= ZoomCamera;
    }

    private void ZoomCamera(InputAction.CallbackContext context)
    {
        float readValue = context.ReadValue<Vector2>().y;
        Debug.Log($"readValue: {readValue}");

        float inputValue = -readValue / 1000f;
        Debug.Log($"inputValue: {inputValue}");

        if(Mathf.Abs(inputValue) > 0.1f)
        {
            if(inputValue > 0)
            {
                zoomHeight = cam.orthographicSize + stepSize;
            }
            else
            {
                zoomHeight = cam.orthographicSize - stepSize;
            }
            Debug.Log($"zoom height: {zoomHeight}");


            if (zoomHeight < minHeight)
                zoomHeight = minHeight;
            else if (zoomHeight > maxHeight)
                zoomHeight = maxHeight;
        }
        
    }

    private void UpdateCameraPosition()
    {
        //Vector3 zoomTarget = new Vector3(cameraTransform.localPosition.x, zoomHeight, cameraTransform.localPosition.z);
        float zoomTarget = zoomHeight;


        //zoomTarget -= zoomSpeed * (zoomHeight - cameraTransform.localPosition.y) * Vector3.forward;
        zoomTarget += zoomSpeed * zoomHeight;

        //cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, zoomTarget, Time.deltaTime * zoomDampening);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomTarget, Time.deltaTime * zoomDampening);

        cameraTransform.LookAt(this.transform);
    }

    private Vector3 GetCameraForward()
    {
        Vector3 forward = cameraTransform.up;
        forward.z = 0f;
        return forward;
    }

    private Vector3 GetCameraRight()
    {
        Vector3 right = cameraTransform.right;
        right.z = 0f;
        return right;
    }

    private void UpdateVelocity()
    {
        horizontalVelocity = (this.transform.position - lastPosition) / Time.deltaTime;
        horizontalVelocity.z = 0f;
        lastPosition = this.transform.position;
    }

    private void GetKeyboardMovement()
    {
        Vector3 inputValue = movement.ReadValue<Vector2>().x * GetCameraRight() + movement.ReadValue<Vector2>().y * GetCameraForward();

        inputValue = inputValue.normalized;

        if (inputValue.sqrMagnitude > 0.1f)
            targetPosition += inputValue;
    }

    private void UpdateBasePosition()
    {
        if(targetPosition.sqrMagnitude > 0.1f)
        {
            speed = Mathf.Lerp(speed, maxSpeed, Time.deltaTime * acceleration);
            transform.position += targetPosition * speed * Time.deltaTime;
        }
        else
        {
            horizontalVelocity = Vector3.Lerp(horizontalVelocity, Vector3.zero, Time.deltaTime * damping);
            transform.position += horizontalVelocity * Time.deltaTime;
        }

        targetPosition = Vector3.zero;
    }

    private void Update()
    {
        GetKeyboardMovement();

        UpdateVelocity();
        UpdateBasePosition();
        UpdateCameraPosition();
    }
}
