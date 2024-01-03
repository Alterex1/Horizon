using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class SelectionBox : MonoBehaviour
{
    private InputSystem inputSystem;

    private Vector3 startPosition;
    private RTSController rtsController;
    [SerializeField] private LayerMask selectableLayerMask;

    private void Start()
    {
        rtsController = RTSController.Instance;
        inputSystem = InputSystem.Instance;

        inputSystem.OnSelectStartedAction += InputSystem_SelectStartedAction;
        inputSystem.OnSelectReleasedAction += InputSystem_SelectReleasedAction;

        inputSystem.OnMultiSelectStartedAction += InputSystem_MultiSelectStartedAction;
        inputSystem.OnMultiSelectReleasedAction += InputSystem_MultiSelectReleasedAction;

        inputSystem.OnToggleSelectStartedAction += InputSystem_ToggleSelectStartedAction;
        inputSystem.OnToggleSelectReleasedAction += InputSystem_ToggleSelectReleasedAction;

    }

    private void InputSystem_SelectStartedAction()
    {
        startPosition = MouseWorld.GetMouseWorldPosition();
    }

    private void InputSystem_SelectReleasedAction()
    {
        rtsController.DeselectAll();

        Collider2D[] collider2DArray;
        Vector3 mousePosition = MouseWorld.GetMouseWorldPosition();

        if (startPosition == mousePosition)
        { // Check if the mouse has stayed in the same place, meaning no selection box dragging has been done.

            collider2DArray = Physics2D.OverlapAreaAll(startPosition, mousePosition, selectableLayerMask);

            foreach (Collider2D collider2D in collider2DArray)
            { // Loop through all the colliders in the selection box

                if (collider2D.TryGetComponent<ShipUnit>(out ShipUnit shipUnit))
                { // Select only the first ShipUnit found

                    rtsController.TryAddSelectedUnit(shipUnit);
                }
            }
        }
        else
        { // Otherwise selection box dragging has been done.
        
            collider2DArray = Physics2D.OverlapAreaAll(startPosition, mousePosition, selectableLayerMask);

            foreach (Collider2D collider2D in collider2DArray)
            { // Loop through all the colliders in the selection box

                ShipUnit shipUnit = collider2D.GetComponent<ShipUnit>();
                if (shipUnit != null)
                { // Select all the ShipUnits found

                    rtsController.TryAddSelectedUnit(shipUnit);
                }
            }
        }
    }

    private void InputSystem_MultiSelectStartedAction()
    {
       startPosition = MouseWorld.GetMouseWorldPosition(); 
    }

    private void InputSystem_MultiSelectReleasedAction()
    {
        Collider2D[] collider2DArray;
        Vector3 mousePosition = MouseWorld.GetMouseWorldPosition();

        if (startPosition == mousePosition)
        { // Check if the mouse has stayed in the same place, meaning no selection box dragging has been done.

            collider2DArray = Physics2D.OverlapAreaAll(startPosition, mousePosition, selectableLayerMask);

            foreach (Collider2D collider2D in collider2DArray)
            {
                if (collider2D.TryGetComponent<ShipUnit>(out ShipUnit shipUnit))
                { // Select only the first ShipUnit found

                    rtsController.TryAddSelectedUnit(shipUnit);
                }
            }
        }
        else
        { // Otherwise selection box dragging has been done.

            collider2DArray = Physics2D.OverlapAreaAll(startPosition, mousePosition, selectableLayerMask);

            foreach (Collider2D collider2D in collider2DArray)
            { // Loop through all the colliders in the selection box

                if (collider2D.TryGetComponent<ShipUnit>(out ShipUnit shipUnit))
                { // Select all the ShipUnits found

                    rtsController.TryAddSelectedUnit(shipUnit);
                }
            }
        }
    }

    private void InputSystem_ToggleSelectStartedAction()
    {
       startPosition = MouseWorld.GetMouseWorldPosition(); 
    }

    private void InputSystem_ToggleSelectReleasedAction()
    {
        Collider2D[] collider2DArray;
        Vector3 mousePosition = MouseWorld.GetMouseWorldPosition();

        if (startPosition == mousePosition)
        { // Check if the mouse has stayed in the same place, meaning no selection box dragging has been done.

            collider2DArray = Physics2D.OverlapAreaAll(startPosition, mousePosition, selectableLayerMask);

            foreach (Collider2D collider2D in collider2DArray)
            {
                if (collider2D.TryGetComponent<ShipUnit>(out ShipUnit shipUnit))
                { // Select only the first ShipUnit found

                    if (rtsController.TryRemoveSelectedUnit(shipUnit))
                    { // Deselect the current unit if it is selected, 

                    }
                    else 
                    { // Otherwise select the current unit 
                        rtsController.TryAddSelectedUnit(shipUnit); 
                    }
                    return;
                }
            }
        }
        else
        { // Otherwise selection box dragging has been done.

            collider2DArray = Physics2D.OverlapAreaAll(startPosition, mousePosition, selectableLayerMask);

            foreach (Collider2D collider2D in collider2DArray)
            { // Loop through all the colliders in the selection box

                if (collider2D.TryGetComponent<ShipUnit>(out ShipUnit shipUnit))
                { 

                    if (rtsController.TryRemoveSelectedUnit(shipUnit))
                    { // Deselect the current unit if it is selected, 

                    }
                    else 
                    { // Otherwise select the current unit 
                        rtsController.TryAddSelectedUnit(shipUnit); 
                    }
                }
            }
        }
    }

}
