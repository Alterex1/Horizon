using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class SelectionBox : MonoBehaviour
{
    private InputSystem inputSystem;

    private Vector3 startPosition;
    private RTSController rtsController;

    private void Start()
    {
        rtsController = RTSController.Instance;
        inputSystem = InputSystem.Instance;

        inputSystem.OnSelectStartedAction += InputSystem_SelectStartedAction;
        inputSystem.OnSelectReleasedAction += InputSystem_SelectReleasedAction;

    }

    private void InputSystem_SelectStartedAction()
    {
        rtsController.DeselectAll();
        startPosition = MouseWorld.GetMouseWorldPosition();
    }

    private void InputSystem_SelectReleasedAction()
    {
        Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(startPosition, MouseWorld.GetMouseWorldPosition());

        foreach (Collider2D collider2D in collider2DArray)
        { // Loop through all the colliders in the selection box

            ShipUnit shipUnit = collider2D.GetComponent<ShipUnit>();
            if (shipUnit != null)
            {
                rtsController.AddSelectedUnit(shipUnit);
            }
        }

    }


}
