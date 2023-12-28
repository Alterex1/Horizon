using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RTSCameraSystem : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] private float moveSpeed = 5f;
    private float worldSize;

    private InputSystem inputSystem;
    private float zoomSpeed = 10f;
    private float targetZoomDistance = 5f;
    private float minZoomDistance = 1f;
    private float maxZoomDistance = 15;

    private void Start()
    {
        inputSystem = InputSystem.Instance;
        worldSize = RTSController.Instance.GetWorldSize();

        inputSystem.OnCameraZoomAction += InputSystem_OnCameraZoomAction;
    }

    private void Update()
    {
        HandleCameraMovement();
        HandleCameraScrolling();
    }

    private void HandleCameraMovement()
    {
        float moveSpeed = this.moveSpeed * targetZoomDistance;

        Vector2 inputVector = inputSystem.GetCameraMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, transform.position.z);

        Vector3 newPosition = transform.position + (moveDir * moveSpeed * Time.deltaTime);
        newPosition.x = Mathf.Clamp(newPosition.x, -worldSize, worldSize);
        newPosition.y = Mathf.Clamp(newPosition.y, -worldSize, worldSize);
        transform.position = newPosition;
    }

    private void HandleCameraScrolling()
    {
        cinemachineVirtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(cinemachineVirtualCamera.m_Lens.OrthographicSize, targetZoomDistance, zoomSpeed * Time.deltaTime);
    }

    private void InputSystem_OnCameraZoomAction()
    {
        int scrollValue = inputSystem.GetZoomScrollValue(); 
        float zoomIncrement = 0.5f;

        if(scrollValue > 0)
        { // Scrolling up

            targetZoomDistance -= zoomIncrement;
        }
        else if(scrollValue < 0)
        { // Scrolling down

            targetZoomDistance += zoomIncrement;
        }

        targetZoomDistance = Mathf.Clamp(targetZoomDistance, minZoomDistance, maxZoomDistance);
    }
}
