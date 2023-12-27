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
    public event Action OnCommandAction;

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

        inputActions.RTS.Command.started += Command_Started;
    }

    private void Select_Started(InputAction.CallbackContext context)
    {
        OnSelectStartedAction?.Invoke();
    }

    private void Select_Canceled(InputAction.CallbackContext context)
    {
        OnSelectReleasedAction?.Invoke();
    }

    private void Command_Started(InputAction.CallbackContext context)
    {
        OnCommandAction?.Invoke();
    }

    private void OnDestroy()
    {
        inputActions.RTS.Select.started -= Select_Started;
        inputActions.RTS.Select.started -= Select_Canceled;

        inputActions.RTS.Command.started -= Command_Started;
    }

    public bool IsSelectPressed()
    {
        return inputActions.RTS.Select.IsPressed();
    }
}
