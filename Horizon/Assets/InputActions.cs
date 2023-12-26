//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""RTS"",
            ""id"": ""eab91805-754e-4730-b43c-a9c441fd3411"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""1b1f2fa5-2ac9-4e1f-8433-46ca0d74eece"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Command"",
                    ""type"": ""Button"",
                    ""id"": ""190f02a0-c639-415d-a8d8-ee9084eed10c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9ef097e1-7ac4-4584-95b4-69115ccd1639"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1fae9484-cbd0-48fc-bbf7-4b3c64377ce5"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Command"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // RTS
        m_RTS = asset.FindActionMap("RTS", throwIfNotFound: true);
        m_RTS_Select = m_RTS.FindAction("Select", throwIfNotFound: true);
        m_RTS_Command = m_RTS.FindAction("Command", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // RTS
    private readonly InputActionMap m_RTS;
    private List<IRTSActions> m_RTSActionsCallbackInterfaces = new List<IRTSActions>();
    private readonly InputAction m_RTS_Select;
    private readonly InputAction m_RTS_Command;
    public struct RTSActions
    {
        private @InputActions m_Wrapper;
        public RTSActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_RTS_Select;
        public InputAction @Command => m_Wrapper.m_RTS_Command;
        public InputActionMap Get() { return m_Wrapper.m_RTS; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RTSActions set) { return set.Get(); }
        public void AddCallbacks(IRTSActions instance)
        {
            if (instance == null || m_Wrapper.m_RTSActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_RTSActionsCallbackInterfaces.Add(instance);
            @Select.started += instance.OnSelect;
            @Select.performed += instance.OnSelect;
            @Select.canceled += instance.OnSelect;
            @Command.started += instance.OnCommand;
            @Command.performed += instance.OnCommand;
            @Command.canceled += instance.OnCommand;
        }

        private void UnregisterCallbacks(IRTSActions instance)
        {
            @Select.started -= instance.OnSelect;
            @Select.performed -= instance.OnSelect;
            @Select.canceled -= instance.OnSelect;
            @Command.started -= instance.OnCommand;
            @Command.performed -= instance.OnCommand;
            @Command.canceled -= instance.OnCommand;
        }

        public void RemoveCallbacks(IRTSActions instance)
        {
            if (m_Wrapper.m_RTSActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IRTSActions instance)
        {
            foreach (var item in m_Wrapper.m_RTSActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_RTSActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public RTSActions @RTS => new RTSActions(this);
    public interface IRTSActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnCommand(InputAction.CallbackContext context);
    }
}