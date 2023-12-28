using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputSystem : MonoBehaviour
{
    public static InputSystem Instance { get; private set; }

    private InputActions inputActions;

    public event Action OnSelectStartedAction;
    public event Action OnSelectReleasedAction;
    public event Action OnMultiSelectStartedAction;
    public event Action OnMultiSelectReleasedAction;
    public event Action OnToggleSelectStartedAction;
    public event Action OnToggleSelectReleasedAction;
    public event Action OnCommandAction;
    public event Action OnCameraZoomAction;

    private void Awake()
    {

        if (Instance != null)
        {
            Debug.LogError($"There's more than one InputSystem {transform}-{Instance}");
            Destroy(gameObject);
            return;
        }
        Instance = this;

        inputActions = new InputActions();
        inputActions.RTS.Enable();

        inputActions.RTS.Select.started += Select_Started;
        inputActions.RTS.Select.canceled += Select_Canceled;

        inputActions.RTS.MultiSelect.started += MultiSelect_Started;
        inputActions.RTS.MultiSelect.canceled += MultiSelect_Canceled;

        inputActions.RTS.ToggleSelect.started += ToggleSelect_Started;
        inputActions.RTS.ToggleSelect.canceled += ToggleSelect_Canceled;

        inputActions.RTS.Command.started += Command_Started;

        inputActions.RTS.CameraZoom.performed += CameraZoom_Performed;
    }


    private void Select_Started(InputAction.CallbackContext context)
    {
        OnSelectStartedAction?.Invoke();
    }

    private void Select_Canceled(InputAction.CallbackContext context)
    {
        OnSelectReleasedAction?.Invoke();
    }

    private void MultiSelect_Started(InputAction.CallbackContext context)
    {
        OnMultiSelectStartedAction?.Invoke();
    }

    private void MultiSelect_Canceled(InputAction.CallbackContext context)
    {
        OnMultiSelectReleasedAction?.Invoke();
    }

    private void ToggleSelect_Started(InputAction.CallbackContext context)
    {
        OnToggleSelectStartedAction?.Invoke();
    }

    private void ToggleSelect_Canceled(InputAction.CallbackContext context)
    {
        OnToggleSelectReleasedAction?.Invoke();
    }

    private void Command_Started(InputAction.CallbackContext context)
    {
        OnCommandAction?.Invoke();
    }

    private void CameraZoom_Performed(InputAction.CallbackContext context)
    {
        OnCameraZoomAction?.Invoke();
    }

    private void OnDestroy()
    {
        inputActions.RTS.Select.started -= Select_Started;
        inputActions.RTS.Select.canceled -= Select_Canceled;

        inputActions.RTS.MultiSelect.started -= MultiSelect_Started;
        inputActions.RTS.MultiSelect.canceled -= MultiSelect_Canceled;

        inputActions.RTS.ToggleSelect.started -= ToggleSelect_Started;
        inputActions.RTS.ToggleSelect.canceled -= ToggleSelect_Canceled;

        inputActions.RTS.Command.started -= Command_Started;

        inputActions.RTS.CameraZoom.performed -= CameraZoom_Performed;

        inputActions.Dispose();
    }

    public bool IsSelectPressed()
    {
        return inputActions.RTS.Select.IsPressed();
    }

    public bool IsMultiSelectPressed()
    {
        return inputActions.RTS.MultiSelect.IsPressed();
    }

    public bool IsToggleSelectPressed()
    {
        return inputActions.RTS.ToggleSelect.IsPressed();
    }

    public Vector2 GetCameraMovementVectorNormalized()
    {
        return inputActions.RTS.CameraMovement.ReadValue<Vector2>().normalized;
    }

    public int GetZoomScrollValue()
    { // If value is positive then scrolling up, if negative then scrolling down, zero if not scrolling
        return (int)(inputActions.RTS.CameraZoom.ReadValue<float>() / 120f);
    }

}
